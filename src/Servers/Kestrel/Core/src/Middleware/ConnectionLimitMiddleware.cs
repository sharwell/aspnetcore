// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal
{
    internal class ConnectionLimitMiddleware
    {
        private readonly ConnectionDelegate _next;
        private readonly ResourceCounter _concurrentConnectionCounter;
        private readonly IKestrelTrace _trace;

        public ConnectionLimitMiddleware(ConnectionDelegate next, long connectionLimit, IKestrelTrace trace)
            : this(next, ResourceCounter.Quota(connectionLimit), trace)
        {
        }

        // For Testing
        internal ConnectionLimitMiddleware(ConnectionDelegate next, ResourceCounter concurrentConnectionCounter, IKestrelTrace trace)
        {
            _next = next;
            _concurrentConnectionCounter = concurrentConnectionCounter;
            _trace = trace;
        }

        public async Task OnConnectionAsync(ConnectionContext connection)
        {
            if (!_concurrentConnectionCounter.TryLockOne())
            {
                KestrelEventSource.Log.ConnectionRejected(connection.ConnectionId);
                _trace.ConnectionRejected(connection.ConnectionId);
                connection.Transport.Input.Complete();
                connection.Transport.Output.Complete();
                return;
            }

            var releasor = new ConnectionReleasor(_concurrentConnectionCounter);

            try
            {
                connection.Features.Set<IDecrementConcurrentConnectionCountFeature>(releasor);
                await _next(connection);
            }
            finally
            {
                releasor.ReleaseConnection();
            }
        }

        private class ConnectionReleasor : IDecrementConcurrentConnectionCountFeature
        {
            private readonly ResourceCounter _concurrentConnectionCounter;
            private bool _connectionReleased;

            public ConnectionReleasor(ResourceCounter normalConnectionCounter)
            {
                _concurrentConnectionCounter = normalConnectionCounter;
            }

            public void ReleaseConnection()
            {
                if (!_connectionReleased)
                {
                    _connectionReleased = true;
                    _concurrentConnectionCounter.ReleaseOne();
                }
            }
        }
    }
}
