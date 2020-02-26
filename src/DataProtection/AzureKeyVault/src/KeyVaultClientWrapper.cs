// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.AspNetCore.DataProtection.AzureKeyVault
{
    internal class KeyVaultClientWrapper : IKeyVaultWrappingClient
    {
        private readonly KeyVaultClient _client;

        public KeyVaultClientWrapper(KeyVaultClient client)
        {
            _client = client;
        }

        public Task<KeyOperationResult> UnwrapKeyAsync(string keyIdentifier, string algorithm, byte[] cipherText)
        {
            return _client.UnwrapKeyAsync(keyIdentifier, algorithm, cipherText);
        }

        public Task<KeyOperationResult> WrapKeyAsync(string keyIdentifier, string algorithm, byte[] cipherText)
        {
            return _client.WrapKeyAsync(keyIdentifier, algorithm, cipherText);
        }
    }
}