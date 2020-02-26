// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Server.Kestrel.Performance
{
    public static class ErrorUtilities
    {
        public static void ThrowInvalidRequestLine()
        {
            throw new InvalidOperationException("Invalid request line");
        }

        public static void ThrowInvalidRequestHeaders()
        {
            throw new InvalidOperationException("Invalid request headers");
        }
    }
}
