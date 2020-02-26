// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Microsoft.AspNetCore.Cors
{
    /// <summary>
    /// Metadata that provides a CORS policy.
    /// </summary>
    public class CorsPolicyMetadata : ICorsPolicyMetadata
    {
        public CorsPolicyMetadata(CorsPolicy policy)
        {
            Policy = policy;
        }

        /// <summary>
        /// The policy which needs to be applied.
        /// </summary>
        public CorsPolicy Policy { get; }
    }
}
