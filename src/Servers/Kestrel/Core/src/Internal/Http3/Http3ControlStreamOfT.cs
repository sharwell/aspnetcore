// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Abstractions;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http3
{
    internal sealed class Http3ControlStream<TContext> : Http3ControlStream, IHostContextContainer<TContext>
    {
        private readonly IHttpApplication<TContext> _application;

        public Http3ControlStream(IHttpApplication<TContext> application, Http3Connection connection, HttpConnectionContext context) : base(connection, context)
        {
            _application = application;
        }

        public override void Execute()
        {
            _ = ProcessRequestAsync(_application);
        }

        // Pooled Host context
        TContext IHostContextContainer<TContext>.HostContext { get; set; }
    }
}
