// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Hosting
{
    public static partial class WebHostBuilderSocketExtensions
    {
        public static Microsoft.AspNetCore.Hosting.IWebHostBuilder UseSockets(this Microsoft.AspNetCore.Hosting.IWebHostBuilder hostBuilder) { throw null; }
        public static Microsoft.AspNetCore.Hosting.IWebHostBuilder UseSockets(this Microsoft.AspNetCore.Hosting.IWebHostBuilder hostBuilder, System.Action<Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.SocketTransportOptions> configureOptions) { throw null; }
    }
}
namespace Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets
{
    public partial class SocketConnectionFactory : Microsoft.AspNetCore.Connections.IConnectionFactory, System.IAsyncDisposable
    {
        public SocketConnectionFactory(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.SocketTransportOptions> options, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory) { }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public System.Threading.Tasks.ValueTask<Microsoft.AspNetCore.Connections.ConnectionContext> ConnectAsync(System.Net.EndPoint endpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
    }
    public sealed partial class SocketTransportFactory : Microsoft.AspNetCore.Connections.IConnectionListenerFactory
    {
        public SocketTransportFactory(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.SocketTransportOptions> options, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory) { }
        public System.Threading.Tasks.ValueTask<Microsoft.AspNetCore.Connections.IConnectionListener> BindAsync(System.Net.EndPoint endpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SocketTransportOptions
    {
        public SocketTransportOptions() { }
        public int Backlog { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int IOQueueCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public long? MaxReadBufferSize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public long? MaxWriteBufferSize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool NoDelay { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
}
