// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using HtmlGenerationWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HtmlGenerationWebSite.Controllers
{
    public class CheckViewData : Controller
    {
        public IActionResult AtViewModel()
        {
            return View(new SuperViewModel());
        }

        public IActionResult NullViewModel()
        {
            return View("AtViewModel");
        }

        public IActionResult ViewModel()
        {
            return View(new SuperViewModel());
        }
    }
}
