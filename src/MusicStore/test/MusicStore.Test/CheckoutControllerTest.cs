// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using MusicStore.Models;
using Xunit;

namespace MusicStore.Controllers
{
    public class CheckoutControllerTest : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CheckoutControllerTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public void AddressAndPayment_ReturnsDefaultView()
        {
            // Arrange
            var controller = new CheckoutController(_fixture.ServiceProvider.GetService<ILogger<CheckoutController>>());

            // Act
            var result = controller.AddressAndPayment();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public async Task AddressAndPayment_RedirectToCompleteWhenSuccessful()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();

            var orderId = 10;
            var order = CreateOrder(10);

            // Session initialization
            var cartId = "CartId_A";
            httpContext.Session = new TestSession();
            httpContext.Session.SetString("Session", cartId);

            // FormCollection initialization
            httpContext.Request.Form =
                new FormCollection(
                    new Dictionary<string, StringValues>()
                        { { "PromoCode", new[] { "FREE" } } }
                    );

            // UserName initialization
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "TestUserName") };
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims));

            // DbContext initialization
            var dbContext = _fixture.Context;
            var cartItems = CreateTestCartItems(
                cartId,
                itemPrice: 10,
                numberOfItem: 1);
            dbContext.AddRange(cartItems.Select(n => n.Album).Distinct());
            dbContext.AddRange(cartItems);
            dbContext.SaveChanges();

            var controller = new CheckoutController(_fixture.ServiceProvider.GetService<ILogger<CheckoutController>>());
            controller.ControllerContext.HttpContext = httpContext;

            // Act
            var result = await controller.AddressAndPayment(dbContext, order, CancellationToken.None);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Complete", redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);
            Assert.NotNull(redirectResult.RouteValues);

            Assert.Equal(orderId, redirectResult.RouteValues["Id"]);
        }

        [Fact]
        public async Task AddressAndPayment_ReturnsOrderIfInvalidPromoCode()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var dbContext = _fixture.Context;

            // AddressAndPayment action reads the Promo code from FormCollection.
            context.Request.Form =
                new FormCollection(new Dictionary<string, StringValues>());

            var controller = new CheckoutController(_fixture.ServiceProvider.GetService<ILogger<CheckoutController>>());
            controller.ControllerContext.HttpContext = context;

            // Do not need actual data for Order; the Order object will be checked for the reference equality.
            var order = CreateOrder();

            // Act
            var result = await controller.AddressAndPayment(dbContext, order, CancellationToken.None);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);

            Assert.NotNull(viewResult.ViewData);
            Assert.Same(order, viewResult.ViewData.Model);
        }

        [Fact]
        public async Task AddressAndPayment_ReturnsOrderIfRequestCanceled()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Form =
                new FormCollection(new Dictionary<string, StringValues>());
            var dbContext = _fixture.Context;

            var controller = new CheckoutController(_fixture.ServiceProvider.GetService<ILogger<CheckoutController>>());
            controller.ControllerContext.HttpContext = context;

            var order = CreateOrder();

            // Act
            var result = await controller.AddressAndPayment(dbContext, order, new CancellationToken(true));

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);

            Assert.NotNull(viewResult.ViewData);
            Assert.Same(order, viewResult.ViewData.Model);
        }

        [Fact]
        public async Task AddressAndPayment_ReturnsOrderIfInvalidOrderModel()
        {
            // Arrange
            var controller = new CheckoutController(_fixture.ServiceProvider.GetService<ILogger<CheckoutController>>());
            controller.ModelState.AddModelError("a", "ModelErrorA");
            var dbContext = _fixture.Context;

            var order = CreateOrder();

            // Act
            var result = await controller.AddressAndPayment(dbContext, order, CancellationToken.None);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);

            Assert.NotNull(viewResult.ViewData);
            Assert.Same(order, viewResult.ViewData.Model);
        }

        private Order CreateOrder(int orderId = 100, string userName = "TestUserA")
            => new Order
            {
                OrderId = orderId,
                Username = userName,
                FirstName = "Macavity",
                LastName = "Clark",
                Address = "11 Meadow Drive",
                City = "Healing",
                State = "IA",
                PostalCode = "DN37 7RU",
                Country = "USK",
                Phone = "555 887876",
                Email = "mc@sample.com"
            };

        [Fact]
        public async Task Complete_ReturnsOrderIdIfValid()
        {
            // Arrange
            var orderId = 100;
            var userName = "TestUserA";
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

            var httpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(claims)),
            };

            var dbContext = _fixture.Context;
            dbContext.Add(CreateOrder(orderId, userName));
            dbContext.SaveChanges();

            var controller = new CheckoutController(_fixture.ServiceProvider.GetService<ILogger<CheckoutController>>());
            controller.ControllerContext.HttpContext = httpContext;

            // Act
            var result = await controller.Complete(dbContext, orderId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);

            Assert.NotNull(viewResult.ViewData);
            Assert.Equal(orderId, viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Complete_ReturnsErrorIfInvalidOrder()
        {
            // Arrange
            var invalidOrderId = 100;
            var dbContext = _fixture.Context;

            var controller = new CheckoutController(_fixture.ServiceProvider.GetService<ILogger<CheckoutController>>());
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = await controller.Complete(dbContext, invalidOrderId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.Equal("Error", viewResult.ViewName);
        }

        private static CartItem[] CreateTestCartItems(string cartId, decimal itemPrice, int numberOfItem)
        {
            var albums = Enumerable.Range(1, 10).Select(n =>
                new Album
                {
                    AlbumId = n,
                    Price = itemPrice,
                    Title = "Greatest Hits",
                    Artist = new Artist
                    {
                        ArtistId = 1,
                        Name = "Kung Fu Kenny"
                    },
                    Genre = new Genre
                    {
                        GenreId = 1,
                        Name = "Rap"
                    }
                }).ToArray();

            var cartItems = Enumerable.Range(1, numberOfItem).Select(n =>
                new CartItem()
                {
                    Count = 1,
                    CartId = cartId,
                    AlbumId = n % 10,
                    Album = albums[n % 10],
                }).ToArray();

            return cartItems;
        }
    }
}
