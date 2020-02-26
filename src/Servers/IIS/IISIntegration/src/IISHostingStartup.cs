// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Microsoft.AspNetCore.Server.IISIntegration.IISHostingStartup))]

namespace Microsoft.AspNetCore.Server.IISIntegration
{
    public class IISHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.UseIISIntegration();
        }
    }
}
