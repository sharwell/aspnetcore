// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Http.Connections
{
    /// <summary>
    /// Options used to configure the long polling transport.
    /// </summary>
    public class LongPollingOptions
    {
        /// <summary>
        /// Gets or sets the poll timeout.
        /// </summary>
        public TimeSpan PollTimeout { get; set; } = TimeSpan.FromSeconds(90);
    }
}
