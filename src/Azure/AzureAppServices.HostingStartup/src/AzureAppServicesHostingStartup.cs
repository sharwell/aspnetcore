// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Microsoft.AspNetCore.AzureAppServices.HostingStartup.AzureAppServicesHostingStartup))]

namespace Microsoft.AspNetCore.AzureAppServices.HostingStartup
{
    /// <summary>
    /// A dynamic azure lightup experience
    /// </summary>
    public class AzureAppServicesHostingStartup : IHostingStartup
    {
        private const string HostingStartupName = "AppServices";
        private const string DiagnosticsFeatureName = "DiagnosticsEnabled";

        /// <summary>
        /// Calls UseAzureAppServices
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(IWebHostBuilder builder)
        {
            var baseConfiguration = HostingStartupConfigurationExtensions.GetBaseConfiguration();

            if (baseConfiguration.IsEnabled(HostingStartupName, DiagnosticsFeatureName))
            {
                builder.UseAzureAppServices();
            }
        }
    }
}
