// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Authorization.Infrastructure
{
    /// <summary>
    /// A helper class to provide a useful <see cref="IAuthorizationRequirement"/> which
    /// contains a name.
    /// </summary>
    public class OperationAuthorizationRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// The name of this instance of <see cref="IAuthorizationRequirement"/>.
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(OperationAuthorizationRequirement)}:Name={Name}";
        }
    }
}
