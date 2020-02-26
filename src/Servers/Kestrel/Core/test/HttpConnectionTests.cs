// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO.Pipelines;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.AspNetCore.Testing;
using Moq;
using Xunit;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Tests
{
    public class HttpConnectionTests
    {
        [Fact]
        public async Task WriteDataRateTimeoutAbortsConnection()
        {
            var mockConnectionContext = new Mock<ConnectionContext>();

            var httpConnectionContext = new HttpConnectionContext
            {
                ConnectionContext = mockConnectionContext.Object,
                Transport = new DuplexPipe(Mock.Of<PipeReader>(), Mock.Of<PipeWriter>()),
                ServiceContext = new TestServiceContext()
            };

            var httpConnection = new HttpConnection(httpConnectionContext);

            var aborted = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            var http1Connection = new Http1Connection(httpConnectionContext);

            httpConnection.Initialize(http1Connection);
            http1Connection.Reset();
            http1Connection.RequestAborted.Register(() =>
            {
                aborted.SetResult(null);
            });

            httpConnection.OnTimeout(TimeoutReason.WriteDataRate);

            mockConnectionContext
                .Verify(c => c.Abort(It.Is<ConnectionAbortedException>(ex => ex.Message == CoreStrings.ConnectionTimedBecauseResponseMininumDataRateNotSatisfied)),
                    Times.Once);

            await aborted.Task.DefaultTimeout();
        }
    }
}
