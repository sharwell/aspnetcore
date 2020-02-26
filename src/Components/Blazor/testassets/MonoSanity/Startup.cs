// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MonoSanity
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseFileServer(new FileServerOptions() { EnableDefaultFiles = true, });
            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<MonoSanityClient.Program>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapFallbackToClientSideBlazor<MonoSanityClient.Program>("index.html");
            });
        }
    }
}
