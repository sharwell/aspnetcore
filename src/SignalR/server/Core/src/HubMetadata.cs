// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.SignalR
{
    /// <summary>
    /// Metadata that describes the <see cref="Hub"/> information associated with a specific endpoint.
    /// </summary>
    public class HubMetadata
    {
        public HubMetadata(Type hubType)
        {
            HubType = hubType;
        }

        /// <summary>
        /// The type of <see cref="Hub"/>.
        /// </summary>
        public Type HubType { get; }
    }
}
