// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Routing
{
    /// <summary>
    /// Represents metadata used during link generation to find
    /// the associated endpoint using route name.
    /// </summary>
    public interface IRouteNameMetadata
    {
        /// <summary>
        /// Gets the route name. Can be null.
        /// </summary>
        string RouteName { get; }
    }
}
