// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace RazorWebSite.Controllers
{
    public class PartialsWithLayoutController : Controller
    {
        public IActionResult PartialDoesNotExecuteViewStarts()
        {
            return PartialView("PartialThatDoesNotSpecifyLayout");
        }

        // This action demonstrates
        // (a) _ViewStart does not get executed when executing a partial via RenderPartial
        // (b) Partials rendered via RenderPartial can execute Layout.
        public IActionResult PartialsRenderedViaRenderPartial()
        {
            return View();
        }

        // This action demonstrates
        // (a) _ViewStart does not get executed when executing a partial via PartialAsync
        // (b) Partials rendered via PartialAsync can execute Layout.
        public IActionResult PartialsRenderedViaPartialAsync()
        {
            return View(nameof(PartialsRenderedViaPartialAsync));
        }
    }
}
