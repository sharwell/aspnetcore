// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Cryptography.Cng
{
    /// <summary>
    /// Wraps utility BCRYPT APIs that don't work directly with handles.
    /// </summary>
    internal unsafe static class BCryptUtil
    {
        /// <summary>
        /// Fills a buffer with cryptographically secure random data.
        /// </summary>
        public static void GenRandom(byte* pbBuffer, uint cbBuffer)
        {
            if (cbBuffer != 0)
            {
                int ntstatus = UnsafeNativeMethods.BCryptGenRandom(
                    hAlgorithm: IntPtr.Zero,
                    pbBuffer: pbBuffer,
                    cbBuffer: cbBuffer,
                    dwFlags: BCryptGenRandomFlags.BCRYPT_USE_SYSTEM_PREFERRED_RNG);
                UnsafeNativeMethods.ThrowExceptionForBCryptStatus(ntstatus);
            }
        }
    }
}
