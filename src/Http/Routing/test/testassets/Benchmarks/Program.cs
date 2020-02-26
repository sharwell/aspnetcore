// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GetWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder GetWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "RoutingBenchmarks_")
                .Build();

            // Consoler logger has a major impact on perf results, so do not use
            // default builder.

            var webHostBuilder = new WebHostBuilder()
                    .UseConfiguration(config)
                    .UseKestrel();

            var scenario = config["scenarios"]?.ToLower();
            if (scenario == "plaintextdispatcher" || scenario == "plaintextendpointrouting")
            {
                webHostBuilder.UseStartup<StartupUsingEndpointRouting>();
                // for testing
                webHostBuilder.UseSetting("Startup", nameof(StartupUsingEndpointRouting));
            }
            else if (scenario == "plaintextrouting" || scenario == "plaintextrouter")
            {
                webHostBuilder.UseStartup<StartupUsingRouter>();
                // for testing
                webHostBuilder.UseSetting("Startup", nameof(StartupUsingRouter));
            }
            else
            {
                throw new InvalidOperationException(
                    $"Invalid scenario '{scenario}'. Allowed scenarios are PlaintextEndpointRouting and PlaintextRouter");
            }

            return webHostBuilder;
        }
    }
}
