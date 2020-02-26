// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Tools.Internal;

namespace Microsoft.Extensions.ApiDescription.Tool.Commands
{
    internal class HelpCommandBase : CommandBase
    {
        public HelpCommandBase(IConsole console) : base(console)
        {
        }

        public override void Configure(CommandLineApplication command)
        {
            command.HelpOption();
            command.VersionOptionFromAssemblyAttributes();
            base.Configure(command);
        }
    }
}
