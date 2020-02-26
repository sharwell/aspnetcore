// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal.Networking
{
    internal static class PlatformApis
    {
        public static bool IsWindows { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsDarwin { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long VolatileRead(ref long value)
        {
            if (IntPtr.Size == 8)
            {
                return Volatile.Read(ref value);
            }
            else
            {
                // Avoid torn long reads on 32-bit
                return Interlocked.Read(ref value);
            }
        }
    }
}
