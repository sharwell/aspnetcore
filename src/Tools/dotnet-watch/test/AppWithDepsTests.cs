// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.DotNet.Watcher.Tools.FunctionalTests
{
    public class AppWithDepsTests : IDisposable
    {
        private readonly AppWithDeps _app;

        public AppWithDepsTests(ITestOutputHelper logger)
        {
            _app = new AppWithDeps(logger);
        }

        [Fact]
        [Flaky("<No longer needed; tracked in Kusto>", FlakyOn.All)]
        public async Task ChangeFileInDependency()
        {
            await _app.StartWatcherAsync();

            var fileToChange = Path.Combine(_app.DependencyFolder, "Foo.cs");
            var programCs = File.ReadAllText(fileToChange);
            File.WriteAllText(fileToChange, programCs);

            await _app.HasRestarted();
        }

        public void Dispose()
        {
            _app.Dispose();
        }

        private class AppWithDeps : WatchableApp
        {
            private const string Dependency = "Dependency";

            public AppWithDeps(ITestOutputHelper logger)
                : base("AppWithDeps", logger)
            {
                Scenario.AddTestProjectFolder(Dependency);

                DependencyFolder = Path.Combine(Scenario.WorkFolder, Dependency);
            }

            public string DependencyFolder { get; private set; }
        }
    }
}
