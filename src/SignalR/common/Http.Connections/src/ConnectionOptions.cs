// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Http.Connections
{
    public class ConnectionOptions
    {
        /// <summary>
        /// Gets or sets the interval used by the server to timeout idle connections.
        /// </summary>
        public TimeSpan? DisconnectTimeout { get; set; }
    }
}
