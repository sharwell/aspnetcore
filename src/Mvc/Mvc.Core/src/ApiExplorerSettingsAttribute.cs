// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// Controls the visibility and group name for an <c>ApiDescription</c>
    /// of the associated controller class or action method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ApiExplorerSettingsAttribute :
        Attribute,
        IApiDescriptionGroupNameProvider,
        IApiDescriptionVisibilityProvider
    {
        /// <inheritdoc />
        public string GroupName { get; set; }

        /// <inheritdoc />
        public bool IgnoreApi { get; set; }
    }
}