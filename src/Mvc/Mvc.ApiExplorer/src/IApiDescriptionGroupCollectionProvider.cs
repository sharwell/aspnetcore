// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.ApiExplorer
{
    /// <summary>
    /// Provides access to a collection of <see cref="ApiDescriptionGroup"/>.
    /// </summary>
    public interface IApiDescriptionGroupCollectionProvider
    {
        /// <summary>
        /// Gets a collection of <see cref="ApiDescriptionGroup"/>.
        /// </summary>
        ApiDescriptionGroupCollection ApiDescriptionGroups { get; }
    }
}