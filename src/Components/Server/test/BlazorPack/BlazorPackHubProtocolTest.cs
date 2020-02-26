// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.SignalR.Common.Tests.Internal.Protocol;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Microsoft.AspNetCore.Components.Server.BlazorPack
{
    public class BlazorPackHubProtocolTest : MessagePackHubProtocolTestBase
    {
        protected override IHubProtocol HubProtocol { get; } = new BlazorPackHubProtocol();
    }
}
