// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace HtmlGenerationWebSite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HtmlGeneration_CustomerController : Controller
    {
        public IActionResult Index(Models.Customer customer)
        {
            return View("Customer");
        }
    }
}