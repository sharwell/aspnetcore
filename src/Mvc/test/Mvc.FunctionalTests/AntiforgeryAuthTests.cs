﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SecurityWebSite;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.FunctionalTests
{
    public class AntiforgeryAuthTests : IClassFixture<MvcTestFixture<Startup>>
    {
        public AntiforgeryAuthTests(MvcTestFixture<Startup> fixture)
        {
            Client = fixture.CreateDefaultClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task AutomaticAuthenticationBeforeAntiforgery()
        {
            // Arrange & Act
            var response = await Client.PostAsync("http://localhost/Home/AutoAntiforgery", null);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/Home/Login", response.Headers.Location.AbsolutePath, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task AuthBeforeAntiforgery()
        {
            // Arrange & Act
            var response = await Client.GetAsync("http://localhost/Home/Antiforgery");

            // Assert
            // Redirected to login page, Antiforgery didn't fail yet
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/Home/Login", response.Headers.Location.AbsolutePath, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task IgnoreAntiforgeryOverridesAutoAntiforgery()
        {
            // Arrange & Act
            var response = await Client.PostAsync("http://localhost/Antiforgery/Index", content: null);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AntiforgeryOverridesIgnoreAntiforgery()
        {
            // Arrange & Act
            var response = await Client.PostAsync("http://localhost/IgnoreAntiforgery/Index", content: null);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
