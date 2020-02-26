﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Microsoft.AspNetCore.Mvc.Analyzers
{
    public class DiagnosticsAreReturned_IfAllowAnonymousIsAppliedToPageHandlerMethod : PageModel
    {
        [/*MM*/AllowAnonymous]
        public void OnGet()
        {

        }

        public void OnPost()
        {
        }
    }
}
