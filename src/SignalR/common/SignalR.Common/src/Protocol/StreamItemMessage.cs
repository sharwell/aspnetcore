// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.SignalR.Protocol
{
    public class StreamItemMessage : HubInvocationMessage
    {
        public object Item { get; }

        public StreamItemMessage(string invocationId, object item) : base(invocationId)
        {
            Item = item;
        }

        public override string ToString()
        {
            return $"StreamItem {{ {nameof(InvocationId)}: \"{InvocationId}\", {nameof(Item)}: {Item ?? "<<null>>"} }}";
        }
    }
}
