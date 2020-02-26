// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FormatterWebSite
{
    public class StartupWithComplexParentValidation
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(options => options.ValidateComplexTypesIfChildValidationFails = true)
                .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Insert(0, new IModelConverter()))
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}