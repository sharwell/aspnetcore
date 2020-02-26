// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Abstractions;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http3
{
    class Http3Stream<TContext> : Http3Stream, IHostContextContainer<TContext>
    {
        private readonly IHttpApplication<TContext> _application;

        public Http3Stream(IHttpApplication<TContext> application, Http3Connection connection, Http3StreamContext context) : base(connection, context)
        {
            _application = application;
        }

        public override void Execute()
        {
            if (_requestHeaderParsingState == Http3Stream.RequestHeaderParsingState.Ready)
            {
                _ = ProcessRequestAsync(_application);
            }
            else
            {
                _ = base.ProcessRequestsAsync(_application);
            }
        }

        // Pooled Host context
        TContext IHostContextContainer<TContext>.HostContext { get; set; }
    }
}
