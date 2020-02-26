// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http
{
    public enum HttpVersion
    {
        Unknown = -1,
        Http10 = 0,
        Http11 = 1,
        Http2 = 2,
        Http3 = 3
    }
}
