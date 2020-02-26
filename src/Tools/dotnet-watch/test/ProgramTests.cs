// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Testing;
using Microsoft.Extensions.Tools.Internal;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.DotNet.Watcher.Tools.Tests
{
    public class ProgramTests : IDisposable
    {
        private readonly TemporaryDirectory _tempDir;
        private readonly TestConsole _console;

        public ProgramTests(ITestOutputHelper output)
        {
            _tempDir = new TemporaryDirectory();
            _console = new TestConsole(output);
        }

        [Fact]
        [Flaky("<No longer required; Tracked in Kusto>", FlakyOn.All)]
        public async Task ConsoleCancelKey()
        {
            _tempDir
                .WithCSharpProject("testproj")
                .WithTargetFrameworks("netcoreapp5.0")
                .Dir()
                .WithFile("Program.cs")
                .Create();

            using (var app = new Program(_console, _tempDir.Root))
            {
                var run = app.RunAsync(new[] { "run" });

                await _console.CancelKeyPressSubscribed.TimeoutAfter(TimeSpan.FromSeconds(30));
                _console.ConsoleCancelKey();

                var exitCode = await run.TimeoutAfter(TimeSpan.FromSeconds(30));

                Assert.Contains("Shutdown requested. Press Ctrl+C again to force exit.", _console.GetOutput());
                Assert.Equal(0, exitCode);
            }
        }

        public void Dispose()
        {
            _tempDir.Dispose();
        }
    }
}
