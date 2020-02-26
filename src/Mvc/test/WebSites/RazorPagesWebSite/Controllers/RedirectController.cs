// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace RazorPagesWebSite
{
    public class RedirectController : Controller
    {
        [HttpGet("/RedirectToPage")]
        public IActionResult RedirectToPageAction()
        {
            return RedirectToPage("/RedirectToController", new { param = 17 });
        }
    }
}
