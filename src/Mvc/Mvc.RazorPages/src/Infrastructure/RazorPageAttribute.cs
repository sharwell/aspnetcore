// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure
{
    [Obsolete("This attribute has been superseded by RazorCompiledItem and will not be used by the runtime.")]
    public class RazorPageAttribute : RazorViewAttribute
    {
        public RazorPageAttribute(string path, Type viewType, string routeTemplate)
            : base(path, viewType)
        {
            RouteTemplate = routeTemplate;
        }

        public string RouteTemplate { get; }
    }
}
