// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http3
{
    internal class Http3PeerSettings
    {
        internal const uint DefaultMaxFrameSize = 16 * 1024;

        public static int MinAllowedMaxFrameSize { get; internal set; } = 16 * 1024;
    }
}
