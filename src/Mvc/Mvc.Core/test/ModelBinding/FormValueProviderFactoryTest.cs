// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Test
{
    public class FormValueProviderFactoryTest
    {
        [Fact]
        public async Task GetValueProviderAsync_ReturnsNull_WhenContentTypeIsNotFormUrlEncoded()
        {
            // Arrange
            var context = CreateContext("some-content-type");
            var factory = new FormValueProviderFactory();

            // Act
            await factory.CreateValueProviderAsync(context);

            // Assert
            Assert.Empty(context.ValueProviders);
        }

        [Theory]
        [InlineData("application/x-www-form-urlencoded")]
        [InlineData("application/x-www-form-urlencoded;charset=utf-8")]
        [InlineData("multipart/form-data; boundary=----WebKitFormBoundarymx2fSWqWSd0OxQqq")]
        [InlineData("multipart/form-data; boundary=----WebKitFormBoundarymx2fSWqWSd0OxQqq; charset=utf-8")]
        public async Task GetValueProviderAsync_ReturnsValueProvider_WithCurrentCulture(string contentType)
        {
            // Arrange
            var context = CreateContext(contentType);
            var factory = new FormValueProviderFactory();

            // Act
            await factory.CreateValueProviderAsync(context);

            // Assert
            var valueProvider = Assert.IsType<FormValueProvider>(Assert.Single(context.ValueProviders));
            Assert.Equal(CultureInfo.CurrentCulture, valueProvider.Culture);
        }

        private static ValueProviderFactoryContext CreateContext(string contentType)
        {
            var context = new DefaultHttpContext();
            context.Request.ContentType = contentType;

            if (context.Request.HasFormContentType)
            {
                context.Request.Form = new FormCollection(new Dictionary<string, StringValues>());
            }

            var actionContext = new ActionContext(context, new RouteData(), new ActionDescriptor());

            return new ValueProviderFactoryContext(actionContext);
        }
    }
}
