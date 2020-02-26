﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Hosting
{
    internal static class HostingStartupConfigurationExtensions
    {
        public static IConfiguration GetBaseConfiguration()
        {
            return new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();
        }
        public static bool IsEnabled(this IConfiguration configuration, string hostingStartupName, string featureName)
        {
            if (configuration.TryGetOption(hostingStartupName, featureName, out var value))
            {
                value = value.ToLowerInvariant();
                return value != "false" && value != "0";
            }

            return true;
        }

        public static bool TryGetOption(this IConfiguration configuration, string hostingStartupName, string featureName, out string value)
        {
            value = configuration[$"HostingStartup:{hostingStartupName}:{featureName}"];
            return !string.IsNullOrEmpty(value);
        }
    }
}