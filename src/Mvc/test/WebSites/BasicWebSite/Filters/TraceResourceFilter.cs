// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasicWebSite
{
    public class TraceResourceFilter : IResourceFilter
    {

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Items[nameof(TraceResourceFilter)] = $"This value was set by {nameof(TraceResourceFilter)}";
        }
    }
}
