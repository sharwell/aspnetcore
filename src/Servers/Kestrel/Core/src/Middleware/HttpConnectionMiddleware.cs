// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Hosting.Server;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal
{
    internal class HttpConnectionMiddleware<TContext>
    {
        private readonly ServiceContext _serviceContext;
        private readonly IHttpApplication<TContext> _application;
        private readonly HttpProtocols _protocols;

        public HttpConnectionMiddleware(ServiceContext serviceContext, IHttpApplication<TContext> application, HttpProtocols protocols)
        {
            _serviceContext = serviceContext;
            _application = application;
            _protocols = protocols;
        }

        public Task OnConnectionAsync(ConnectionContext connectionContext)
        {
            var memoryPoolFeature = connectionContext.Features.Get<IMemoryPoolFeature>();

            var httpConnectionContext = new HttpConnectionContext
            {
                ConnectionId = connectionContext.ConnectionId,
                ConnectionContext = connectionContext,
                Protocols = _protocols,
                ServiceContext = _serviceContext,
                ConnectionFeatures = connectionContext.Features,
                MemoryPool = memoryPoolFeature.MemoryPool,
                Transport = connectionContext.Transport,
                LocalEndPoint = connectionContext.LocalEndPoint as IPEndPoint,
                RemoteEndPoint = connectionContext.RemoteEndPoint as IPEndPoint
            };

            var connection = new HttpConnection(httpConnectionContext);

            return connection.ProcessRequestsAsync(_application);
        }
    }
}
