﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Microsoft.AspNetCore.Mvc.Analyzers.Test
{
    [ServiceFilter(typeof(object))]
    public class NoDiagnosticsAreReturned_IfFiltersAreAppliedToPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
