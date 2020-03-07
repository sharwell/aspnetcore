// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.ApiExplorer
{
    /// <summary>
    /// Represents visibility metadata for an <c>ApiDescription</c>.
    /// </summary>
    public interface IApiDescriptionVisibilityProvider
    {
        /// <summary>
        /// If <c>false</c> then no <c>ApiDescription</c> objects will be created for the associated controller
        /// or action.
        /// </summary>
        bool IgnoreApi { get; }
    }
}