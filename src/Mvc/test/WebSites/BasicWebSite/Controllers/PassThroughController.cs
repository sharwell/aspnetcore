// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BasicWebSite.Components;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebSite.Controllers
{
    public class PassThroughController : Controller
    {
        public IActionResult Index(long value)
        {
            return ViewComponent(typeof(PassThroughViewComponent), new { value });
        }
    }
}
