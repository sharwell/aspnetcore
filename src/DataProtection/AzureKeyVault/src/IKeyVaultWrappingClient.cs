// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.AspNetCore.DataProtection.AzureKeyVault
{
    internal interface IKeyVaultWrappingClient
    {
        Task<KeyOperationResult> UnwrapKeyAsync(string keyIdentifier, string algorithm, byte[] cipherText);
        Task<KeyOperationResult> WrapKeyAsync(string keyIdentifier, string algorithm, byte[] cipherText);
    }
}