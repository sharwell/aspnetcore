// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Testing;
using Microsoft.Extensions.Logging.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Server.Kestrel.FunctionalTests
{
    public class ConnectionMiddlewareTests : LoggedTest
    {
        [Flaky("<No longer needed; tracked in Kusto>", FlakyOn.All)]
        [Fact]
        public async Task ThrowingSynchronousConnectionMiddlewareDoesNotCrashServer()
        {
            var listenOptions = new ListenOptions(new IPEndPoint(IPAddress.Loopback, 0));
            listenOptions.Use(next => context => throw new Exception());

            var serviceContext = new TestServiceContext(LoggerFactory);

            using (var server = new TestServer(TestApp.EchoApp, serviceContext, listenOptions))
            {
                using (var connection = server.CreateConnection())
                {
                    // Will throw because the exception in the connection adapter will close the connection.
                    await Assert.ThrowsAsync<IOException>(async () =>
                    {
                        await connection.Send(
                           "POST / HTTP/1.0",
                           "Content-Length: 1000",
                           "\r\n");

                        for (var i = 0; i < 1000; i++)
                        {
                            await connection.Send("a");
                            await Task.Delay(5);
                        }
                    });
                }
                await server.StopAsync();
            }
        }
    }
}
