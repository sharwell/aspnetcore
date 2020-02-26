// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Xunit;

namespace Microsoft.AspNetCore.Localization
{
    public class RequestLocalizationOptionsExtensionsTest
    {
        [Fact]
        public void AddInitialRequestCultureProvider_ShouldBeInsertedAtFirstPostion()
        {
            // Arrange
            var options = new RequestLocalizationOptions();
            var provider = new CustomRequestCultureProvider(context => Task.FromResult(new ProviderCultureResult("ar-YE")));

            // Act
            options.AddInitialRequestCultureProvider(provider);

            // Assert
            Assert.Same(provider, options.RequestCultureProviders[0]);
        }
    }
}
