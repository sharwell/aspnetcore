// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.FunctionalTests
{
    public class GlobalAuthorizationFilterEndpointRoutingTest : GlobalAuthorizationFilterTestBase, IClassFixture<MvcTestFixture<SecurityWebSite.StartupWithGlobalDenyAnonymousFilter>>
    {
        public GlobalAuthorizationFilterEndpointRoutingTest(MvcTestFixture<SecurityWebSite.StartupWithGlobalDenyAnonymousFilter> fixture)
        {
            Factory = fixture.Factories.FirstOrDefault() ?? fixture.WithWebHostBuilder(ConfigureWebHostBuilder);
            Client = Factory.CreateDefaultClient();
        }

        private static void ConfigureWebHostBuilder(IWebHostBuilder builder) =>
            builder.UseStartup<SecurityWebSite.StartupWithGlobalDenyAnonymousFilter>();

        public WebApplicationFactory<SecurityWebSite.StartupWithGlobalDenyAnonymousFilter> Factory { get; }
    }
}
