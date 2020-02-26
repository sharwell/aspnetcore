// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace MvcSample.Web.Components
{
    public class ComponentWithViewStart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewData["Title"] = "ViewComponent With ViewStart";
            return View();
        }
    }
}