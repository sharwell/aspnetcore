// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace RoutingWebSite
{
    // A very basic routing configuration for LinkGenerator tests
    public class StartupForLinkGenerator
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var pageRouteTransformerConvention = new PageRouteTransformerConvention(new SlugifyParameterTransformer());

            services
                .AddMvc()
                .AddNewtonsoftJson()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddFolderRouteModelConvention("/PageRouteTransformer", model =>
                    {
                        pageRouteTransformerConvention.Apply(model);
                    });
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services
                .AddRouting(options =>
                {
                    options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
                });

            services.AddScoped<TestResponseGenerator>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute("routewithnomvcparameters", "/routewithnomvcparameters/{custom}");
            });
        }
    }
}