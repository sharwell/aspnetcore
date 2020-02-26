// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption
{
    public interface IAuthenticatedEncryptorFactory
    {
        /// <summary>
        /// Creates an <see cref="IAuthenticatedEncryptor"/> instance based on the given <see cref="IKey.Descriptor"/>.
        /// </summary>
        /// <returns>An <see cref="IAuthenticatedEncryptor"/> instance.</returns>
        /// <remarks>
        /// For a given <see cref="IKey.Descriptor"/>, any two instances returned by this method should
        /// be considered equivalent, e.g., the payload returned by one's <see cref="IAuthenticatedEncryptor.Encrypt(ArraySegment{byte}, ArraySegment{byte})"/>
        /// method should be consumable by the other's <see cref="IAuthenticatedEncryptor.Decrypt(ArraySegment{byte}, ArraySegment{byte})"/> method.
        /// </remarks>
        IAuthenticatedEncryptor CreateEncryptorInstance(IKey key);
    }
}
