// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Cryptography;

namespace Microsoft.AspNetCore.DataProtection
{
    /// <summary>
    /// Wrappers around CryptProtectMemory / CryptUnprotectMemory.
    /// </summary>
    internal unsafe static class MemoryProtection
    {
        // from dpapi.h
        private const uint CRYPTPROTECTMEMORY_SAME_PROCESS = 0x00;

        public static void CryptProtectMemory(SafeHandle pBuffer, uint byteCount)
        {
            if (!UnsafeNativeMethods.CryptProtectMemory(pBuffer, byteCount, CRYPTPROTECTMEMORY_SAME_PROCESS))
            {
                UnsafeNativeMethods.ThrowExceptionForLastCrypt32Error();
            }
        }

        public static void CryptUnprotectMemory(byte* pBuffer, uint byteCount)
        {
            if (!UnsafeNativeMethods.CryptUnprotectMemory(pBuffer, byteCount, CRYPTPROTECTMEMORY_SAME_PROCESS))
            {
                UnsafeNativeMethods.ThrowExceptionForLastCrypt32Error();
            }
        }

        public static void CryptUnprotectMemory(SafeHandle pBuffer, uint byteCount)
        {
            if (!UnsafeNativeMethods.CryptUnprotectMemory(pBuffer, byteCount, CRYPTPROTECTMEMORY_SAME_PROCESS))
            {
                UnsafeNativeMethods.ThrowExceptionForLastCrypt32Error();
            }
        }
    }
}
