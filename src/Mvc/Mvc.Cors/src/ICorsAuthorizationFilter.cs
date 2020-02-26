// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.Filters;

namespace Microsoft.AspNetCore.Mvc.Cors
{
    /// <summary>
    /// A filter that can be used to enable/disable CORS support for a resource.
    /// </summary>
    internal interface ICorsAuthorizationFilter : IAsyncAuthorizationFilter, IOrderedFilter
    {
    }
}
