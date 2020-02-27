// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Builder
{
    public static partial class HostFilteringBuilderExtensions
    {
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseHostFiltering(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
    }
    public static partial class HostFilteringServicesExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddHostFiltering(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Microsoft.AspNetCore.HostFiltering.HostFilteringOptions> configureOptions) { throw null; }
    }
}
namespace Microsoft.AspNetCore.HostFiltering
{
    public partial class HostFilteringMiddleware
    {
        public HostFilteringMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNetCore.HostFiltering.HostFilteringMiddleware> logger, Microsoft.Extensions.Options.IOptionsMonitor<Microsoft.AspNetCore.HostFiltering.HostFilteringOptions> optionsMonitor) { }
        public System.Threading.Tasks.Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) { throw null; }
    }
    public partial class HostFilteringOptions
    {
        public HostFilteringOptions() { }
        public System.Collections.Generic.IList<string> AllowedHosts { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool AllowEmptyHosts { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool IncludeFailureMessage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
}
