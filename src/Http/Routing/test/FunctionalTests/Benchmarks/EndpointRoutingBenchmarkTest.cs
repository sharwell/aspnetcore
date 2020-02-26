// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Microsoft.AspNetCore.Routing.FunctionalTests
{
    public class EndpointRoutingBenchmarkTest : IDisposable
    {
        private readonly HttpClient _client;
        private readonly TestServer _testServer;

        public EndpointRoutingBenchmarkTest()
        {
            // This switch and value are set by benchmark server when running the app for profiling.
            var args = new[] { "--scenarios", "PlaintextEndpointRouting" };
            var webHostBuilder = Benchmarks.Program.GetWebHostBuilder(args);

            // Make sure we are using the right startup
            var startupName = webHostBuilder.GetSetting("Startup");
            Assert.Equal(nameof(Benchmarks.StartupUsingEndpointRouting), startupName);

            _testServer = new TestServer(webHostBuilder);
            _client = _testServer.CreateClient();
            _client.BaseAddress = new Uri("http://localhost");
        }

        [Fact]
        public async Task RouteEndpoint_ReturnsPlaintextResponse()
        {
            // Arrange
            var expectedContentType = "text/plain";
            var expectedContent = "Hello, World!";

            // Act
            var response = await _client.GetAsync("/plaintext");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);
            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Equal(expectedContentType, response.Content.Headers.ContentType.MediaType);
            var actualContent = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedContent, actualContent);
        }

        public void Dispose()
        {
            _testServer.Dispose();
            _client.Dispose();
        }
    }
}
