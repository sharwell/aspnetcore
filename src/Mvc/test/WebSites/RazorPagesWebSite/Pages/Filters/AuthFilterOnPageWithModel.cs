// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWebSite.Pages.Filters
{
    [SkipStatusCodePages]
    public class AuthFilterOnPageWithModel : PageModel
    {
        public IActionResult OnGet() => Page();
    }
}
