﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Http.Connections
{
    /// <summary>
    /// Constants related to HTTP transports.
    /// </summary>
    public static class HttpTransports
    {
        /// <summary>
        /// A bitmask combining all available <see cref="HttpTransportType"/> values.
        /// </summary>
        public static readonly HttpTransportType All = HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents | HttpTransportType.LongPolling;
    }
}
