// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using Microsoft.Extensions.Tools.Internal;

namespace Microsoft.DotNet.Watcher
{
    public class PrefixConsoleReporter : ConsoleReporter
    {
        private object _lock = new object();

        private readonly string _prefix;

        public PrefixConsoleReporter(string prefix, IConsole console, bool verbose, bool quiet)
            : base(console, verbose, quiet)
        {
            _prefix = prefix;
        }

        protected override void WriteLine(TextWriter writer, string message, ConsoleColor? color)
        {
            lock (_lock)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                writer.Write(_prefix);
                Console.ResetColor();

                base.WriteLine(writer, message, color);
            }
        }
    }
}
