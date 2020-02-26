// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWebSite
{
    [BindProperties]
    public class BindPropertiesOnModel : PageModel
    {
        [FromQuery]
        public string Property1 { get; set; }

        public string Property2 { get; set; }
    }
}
