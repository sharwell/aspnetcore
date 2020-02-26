// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RoutingWebSite
{
    public class MapFallbackStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapFallback("/prefix/{*path:nonfile}", (context) =>
                {
                    return context.Response.WriteAsync("FallbackCustomPattern");
                });

                endpoints.MapFallback((context) =>
                {
                    return context.Response.WriteAsync("FallbackDefaultPattern");
                });

                endpoints.MapHello("/helloworld", "World");
            });
        }
    }
}
