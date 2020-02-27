// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Hosting.Server
{
    public partial interface IHttpApplication<TContext>
    {
        TContext CreateContext(Microsoft.AspNetCore.Http.Features.IFeatureCollection contextFeatures);
        void DisposeContext(TContext context, System.Exception exception);
        System.Threading.Tasks.Task ProcessRequestAsync(TContext context);
    }
    public partial interface IServer : System.IDisposable
    {
        Microsoft.AspNetCore.Http.Features.IFeatureCollection Features { get; }
        System.Threading.Tasks.Task StartAsync<TContext>(Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext> application, System.Threading.CancellationToken cancellationToken);
        System.Threading.Tasks.Task StopAsync(System.Threading.CancellationToken cancellationToken);
    }
    public partial interface IServerIntegratedAuth
    {
        string AuthenticationScheme { get; }
        bool IsEnabled { get; }
    }
    public partial class ServerIntegratedAuth : Microsoft.AspNetCore.Hosting.Server.IServerIntegratedAuth
    {
        public ServerIntegratedAuth() { }
        public string AuthenticationScheme { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool IsEnabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
}
namespace Microsoft.AspNetCore.Hosting.Server.Abstractions
{
    public partial interface IHostContextContainer<TContext>
    {
        TContext HostContext { get; set; }
    }
}
namespace Microsoft.AspNetCore.Hosting.Server.Features
{
    public partial interface IServerAddressesFeature
    {
        System.Collections.Generic.ICollection<string> Addresses { get; }
        bool PreferHostingUrls { get; set; }
    }
}
