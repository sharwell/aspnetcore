// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.ApiExplorer
{
    /// <summary>
    /// Represents group name metadata for an <c>ApiDescription</c>.
    /// </summary>
    public interface IApiDescriptionGroupNameProvider
    {
        /// <summary>
        /// The group name for the <c>ApiDescription</c> of the associated action or controller.
        /// </summary>
        string GroupName { get; }
    }
}