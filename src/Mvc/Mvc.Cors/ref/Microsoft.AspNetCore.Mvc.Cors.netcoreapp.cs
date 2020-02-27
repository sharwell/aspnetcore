// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Cors
{
    public partial class CorsAuthorizationFilter : Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter, Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata, Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter
    {
        public CorsAuthorizationFilter(Microsoft.AspNetCore.Cors.Infrastructure.ICorsService corsService, Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider policyProvider) { }
        public CorsAuthorizationFilter(Microsoft.AspNetCore.Cors.Infrastructure.ICorsService corsService, Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider policyProvider, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory) { }
        public int Order { get { throw null; } }
        public string PolicyName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public System.Threading.Tasks.Task OnAuthorizationAsync(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext context) { throw null; }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class MvcCorsMvcCoreBuilderExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder AddCors(this Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder builder) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder AddCors(this Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder builder, System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions> setupAction) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder ConfigureCors(this Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder builder, System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions> setupAction) { throw null; }
    }
}
