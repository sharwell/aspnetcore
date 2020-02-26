// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.Filters;

namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// A marker interface for filters which define a policy for limits on a request's body read as a form.
    /// </summary>
    public interface IRequestFormLimitsPolicy : IFilterMetadata
    {
    }
}
