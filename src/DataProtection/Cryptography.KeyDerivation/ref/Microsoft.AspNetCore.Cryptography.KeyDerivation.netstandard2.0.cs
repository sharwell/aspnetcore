// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Cryptography.KeyDerivation
{
    public static partial class KeyDerivation
    {
        public static byte[] Pbkdf2(string password, byte[] salt, Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf prf, int iterationCount, int numBytesRequested) { throw null; }
    }
    public enum KeyDerivationPrf
    {
        HMACSHA1 = 0,
        HMACSHA256 = 1,
        HMACSHA512 = 2,
    }
}
