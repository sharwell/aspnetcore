// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Provides programmatic configuration for the <see cref="CookiePolicyMiddleware"/>.
    /// </summary>
    public class CookiePolicyOptions
    {
        /// <summary>
        /// Affects the cookie's same site attribute.
        /// </summary>
        public SameSiteMode MinimumSameSitePolicy { get; set; } = SameSiteMode.Unspecified;

        /// <summary>
        /// Affects whether cookies must be HttpOnly.
        /// </summary>
        public HttpOnlyPolicy HttpOnly { get; set; } = HttpOnlyPolicy.None;

        /// <summary>
        /// Affects whether cookies must be Secure.
        /// </summary>
        public CookieSecurePolicy Secure { get; set; } = CookieSecurePolicy.None;

        public CookieBuilder ConsentCookie { get; set; } = new CookieBuilder()
        {
            Name = ".AspNet.Consent",
            Expiration = TimeSpan.FromDays(365),
            IsEssential = true,
        };

        /// <summary>
        /// Checks if consent policies should be evaluated on this request. The default is false.
        /// </summary>
        public Func<HttpContext, bool> CheckConsentNeeded { get; set; }

        /// <summary>
        /// Called when a cookie is appended.
        /// </summary>
        public Action<AppendCookieContext> OnAppendCookie { get; set; }

        /// <summary>
        /// Called when a cookie is deleted.
        /// </summary>
        public Action<DeleteCookieContext> OnDeleteCookie { get; set; }
    }
}
