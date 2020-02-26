// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Tools.Internal;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.DotNet.Watcher.Tools.Tests
{
    public class CommandLineOptionsTests
    {
        private readonly TestConsole _console;

        public CommandLineOptionsTests(ITestOutputHelper output)
        {
            _console = new TestConsole(output);
        }

        [Theory]
        [InlineData(new object[] { new[] { "-h" } })]
        [InlineData(new object[] { new[] { "-?" } })]
        [InlineData(new object[] { new[] { "--help" } })]
        [InlineData(new object[] { new[] { "--help", "--bogus" } })]
        [InlineData(new object[] { new[] { "--" } })]
        [InlineData(new object[] { new string[0] })]
        public void HelpArgs(string[] args)
        {
            var options = CommandLineOptions.Parse(args, _console);

            Assert.True(options.IsHelp);
            Assert.Contains("Usage: dotnet watch ", _console.GetOutput());
        }

        [Theory]
        [InlineData(new[] { "run" }, new[] { "run" })]
        [InlineData(new[] { "run", "--", "subarg" }, new[] { "run", "--", "subarg" })]
        [InlineData(new[] { "--", "run", "--", "subarg" }, new[] { "run", "--", "subarg" })]
        [InlineData(new[] { "--unrecognized-arg" }, new[] { "--unrecognized-arg" })]
        public void ParsesRemainingArgs(string[] args, string[] expected)
        {
            var options = CommandLineOptions.Parse(args, _console);

            Assert.Equal(expected, options.RemainingArguments.ToArray());
            Assert.False(options.IsHelp);
            Assert.Empty(_console.GetOutput());
        }

        [Fact]
        public void CannotHaveQuietAndVerbose()
        {
            var ex = Assert.Throws<CommandParsingException>(() => CommandLineOptions.Parse(new[] { "--quiet", "--verbose" }, _console));
            Assert.Equal(Resources.Error_QuietAndVerboseSpecified, ex.Message);
        }
    }
}
