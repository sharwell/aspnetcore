// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.CommandLineUtils;

using static Microsoft.AspNetCore.SignalR.Crankier.Commands.CommandLineUtilities;

namespace Microsoft.AspNetCore.SignalR.Crankier.Commands
{
    internal class AgentCommand
    {
        public static void Register(CommandLineApplication app)
        {
            app.Command("agent", cmd => cmd.OnExecute(() => Fail("Not yet implemented")));
        }
    }
}
