// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.CookiePolicy
{
    public class DeleteCookieContext
    {
        public DeleteCookieContext(HttpContext context, CookieOptions options, string name)
        {
            Context = context;
            CookieOptions = options;
            CookieName = name;
        }

        public HttpContext Context { get; }
        public CookieOptions CookieOptions { get; }
        public string CookieName { get; set; }
        public bool IsConsentNeeded { get; internal set; }
        public bool HasConsent { get; internal set; }
        public bool IssueCookie { get; set; }
    }
}