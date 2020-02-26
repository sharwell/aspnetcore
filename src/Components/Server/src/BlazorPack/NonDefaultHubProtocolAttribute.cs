// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.SignalR.Internal
{
    // Tells SignalR not to add the IHubProtocol with this attribute to all hubs by default
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal class NonDefaultHubProtocolAttribute : Attribute
    {
    }
}
