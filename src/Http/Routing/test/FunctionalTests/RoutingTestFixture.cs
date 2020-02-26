// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Microsoft.AspNetCore.Routing.FunctionalTests
{
    public class RoutingTestFixture<TStartup> : IDisposable
    {
        private readonly TestServer _server;

        public RoutingTestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup(typeof(TStartup));

            _server = new TestServer(builder);

            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost");
        }

        public HttpClient Client { get; }

        public HttpClient CreateClient(string baseAddress)
        {
            var client = _server.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            return client;
        }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
