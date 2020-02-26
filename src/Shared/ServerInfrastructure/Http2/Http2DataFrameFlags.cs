// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2
{
    [Flags]
    internal enum Http2DataFrameFlags : byte
    {
        NONE = 0x0,
        END_STREAM = 0x1,
        PADDED = 0x8
    }
}
