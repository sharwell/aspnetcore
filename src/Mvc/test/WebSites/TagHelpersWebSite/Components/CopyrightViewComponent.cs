// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TagHelpersWebSite
{
    public class CopyrightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string website, int year)
        {
            var dict = new Dictionary<string, object>
            {
                ["website"] = website,
                ["year"] = year
            };

            return View(dict);
        }
    }
}
