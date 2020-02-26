﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SecurityWebSite
{
    public class StartupWithGlobalAuthFilter
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = BearerAuth.CreateTokenValidationParameters();
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireClaimA", policy => policy.RequireClaim("ClaimA"));
                options.AddPolicy("RequireClaimB", policy => policy.RequireClaim("ClaimB"));
            });

            services.AddMvc(o =>
            {
                o.Filters.Add(new AuthorizeFilter("RequireClaimA"));
            })
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AllowAnonymousToPage("/AllowAnonymousPageViaConvention");
                options.Conventions.AuthorizePage("/AuthorizePageViaConvention", "RequireClaimB");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
