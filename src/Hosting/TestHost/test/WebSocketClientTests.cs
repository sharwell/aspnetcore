// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace Microsoft.AspNetCore.TestHost.Tests
{
    public class WebSocketClientTests
    {
        [Theory]
        [InlineData("http://localhost/connect", "localhost")]
        [InlineData("http://localhost:80/connect", "localhost")]
        [InlineData("http://localhost:81/connect", "localhost:81")]
        public async Task ConnectAsync_ShouldSetRequestProperties(string requestUri, string expectedHost)
        {
            string capturedScheme = null;
            string capturedHost = null;
            string capturedPath = null;

            using (var testServer = new TestServer(new WebHostBuilder()
                .Configure(app =>
                {
                    app.Run(ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/connect"))
                        {
                            capturedScheme = ctx.Request.Scheme;
                            capturedHost = ctx.Request.Host.Value;
                            capturedPath = ctx.Request.Path;
                        }
                        return Task.FromResult(0);
                    });
                })))
            {
                var client = testServer.CreateWebSocketClient();

                try
                {
                    await client.ConnectAsync(
                        uri: new Uri(requestUri),
                        cancellationToken: default);
                }
                catch
                {
                    // An exception will be thrown because our dummy endpoint does not implement a full Web socket server
                }
            }

            Assert.Equal("http", capturedScheme);
            Assert.Equal(expectedHost, capturedHost);
            Assert.Equal("/connect", capturedPath);
        }
    }
}
