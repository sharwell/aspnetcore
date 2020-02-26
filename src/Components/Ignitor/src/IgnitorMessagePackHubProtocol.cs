// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.SignalR.Protocol;

namespace Ignitor
{
    public class IgnitorMessagePackHubProtocol : MessagePackHubProtocol, IHubProtocol
    {
        string IHubProtocol.Name => "blazorpack";
    }
}
