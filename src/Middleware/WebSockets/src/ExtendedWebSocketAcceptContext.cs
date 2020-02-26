// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.WebSockets
{
    public class ExtendedWebSocketAcceptContext : WebSocketAcceptContext
    {
        public override string SubProtocol { get; set; }
        public int? ReceiveBufferSize { get; set; }
        public TimeSpan? KeepAliveInterval { get; set; }
    }
}