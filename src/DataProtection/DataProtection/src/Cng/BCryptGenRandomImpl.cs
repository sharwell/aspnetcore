// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Cryptography.Cng;

namespace Microsoft.AspNetCore.DataProtection.Cng
{
    internal unsafe sealed class BCryptGenRandomImpl : IBCryptGenRandom
    {
        public static readonly BCryptGenRandomImpl Instance = new BCryptGenRandomImpl();

        private BCryptGenRandomImpl()
        {
        }

        public void GenRandom(byte* pbBuffer, uint cbBuffer)
        {
            BCryptUtil.GenRandom(pbBuffer, cbBuffer);
        }
    }
}
