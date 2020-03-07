// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using MusicStore.Models;
using Xunit;

namespace MusicStore.Test
{
    public class ShoppingCartTest : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public ShoppingCartTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task ComputesTotal()
        {
            var cartId = Guid.NewGuid().ToString();
            var db = _fixture.Context;
            var a = db.Albums.Add(
                new Album
                {
                    AlbumId = 1,
                    Title = "Greatest Hits",
                    Price = 15.99m,
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
                }).Entity;

            db.CartItems.Add(new CartItem { Album = a, Count = 2, CartId = cartId });

            db.SaveChanges();

            Assert.Equal(31.98m, await ShoppingCart.GetCart(db, cartId).GetTotal());
        }
    }
}
