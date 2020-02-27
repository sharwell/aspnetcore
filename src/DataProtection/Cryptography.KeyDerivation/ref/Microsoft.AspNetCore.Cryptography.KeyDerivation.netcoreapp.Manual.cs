// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Cryptography.KeyDerivation.PBKDF2
{
    internal sealed partial class NetCorePbkdf2Provider : Microsoft.AspNetCore.Cryptography.KeyDerivation.PBKDF2.IPbkdf2Provider
    {
        public NetCorePbkdf2Provider() { }
        public byte[] DeriveKey(string password, byte[] salt, Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf prf, int iterationCount, int numBytesRequested) { throw null; }
    }
}
