// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Cryptography.KeyDerivation.PBKDF2
{
    internal partial interface IPbkdf2Provider
    {
        byte[] DeriveKey(string password, byte[] salt, Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf prf, int iterationCount, int numBytesRequested);
    }

    internal sealed partial class ManagedPbkdf2Provider : Microsoft.AspNetCore.Cryptography.KeyDerivation.PBKDF2.IPbkdf2Provider
    {
        public ManagedPbkdf2Provider() { }
        public byte[] DeriveKey(string password, byte[] salt, Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf prf, int iterationCount, int numBytesRequested) { throw null; }
    }

    internal sealed partial class Win7Pbkdf2Provider : Microsoft.AspNetCore.Cryptography.KeyDerivation.PBKDF2.IPbkdf2Provider
    {
        public Win7Pbkdf2Provider() { }
        public byte[] DeriveKey(string password, byte[] salt, Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf prf, int iterationCount, int numBytesRequested) { throw null; }
    }

    internal sealed partial class Win8Pbkdf2Provider : Microsoft.AspNetCore.Cryptography.KeyDerivation.PBKDF2.IPbkdf2Provider
    {
        public Win8Pbkdf2Provider() { }
        public byte[] DeriveKey(string password, byte[] salt, Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf prf, int iterationCount, int numBytesRequested) { throw null; }
    }
}
