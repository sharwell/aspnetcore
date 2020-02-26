﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Routing
{
    /// <summary>
    /// Represents metadata used during link generation. If <see cref="SuppressLinkGeneration"/> is <c>true</c> 
    /// the associated endpoint will not be used for link generation.
    /// </summary>
    public sealed class SuppressLinkGenerationMetadata : ISuppressLinkGenerationMetadata
    {
        /// <summary>
        /// Gets a value indicating whether the assocated endpoint should be used for link generation.
        /// </summary>
        public bool SuppressLinkGeneration => true;
    }
}