// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Identity
{
    /// <summary>
    /// Used for store specific options
    /// </summary>
    public class StoreOptions
    {
        /// <summary>
        /// If set to a positive number, the default OnModelCreating will use this value as the max length for any 
        /// properties used as keys, i.e. UserId, LoginProvider, ProviderKey.
        /// </summary>
        public int MaxLengthForKeys { get; set; }

        /// <summary>
        /// If set to true, the store must protect all personally identifying data for a user. 
        /// This will be enforced by requiring the store to implement <see cref="IProtectedUserStore{TUser}"/>.
        /// </summary>
        public bool ProtectPersonalData { get; set; }
    }
}