// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity.DefaultUI.WebSite.Pages
{
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Features.Get<ITrackingConsentFeature>().GrantConsent();
        }
    }
}