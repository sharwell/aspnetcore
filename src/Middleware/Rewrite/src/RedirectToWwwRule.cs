// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite.Logging;

namespace Microsoft.AspNetCore.Rewrite
{
    internal class RedirectToWwwRule : IRule
    {
        private const string WwwDot = "www.";

        private readonly string[] _domains;
        private readonly int _statusCode;

        public RedirectToWwwRule(int statusCode)
        {
            _statusCode = statusCode;
        }

        public RedirectToWwwRule(int statusCode, params string[] domains)
        {
            if (domains == null)
            {
                throw new ArgumentNullException(nameof(domains));
            }

            if (domains.Length < 1)
            {
                throw new ArgumentException($"One or more {nameof(domains)} must be provided.");
            }

            _domains = domains;
            _statusCode = statusCode;
        }

        public void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;

            var hostInDomains = RedirectToWwwHelper.IsHostInDomains(req, _domains);

            if (!hostInDomains)
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            if (req.Host.Value.StartsWith(WwwDot, StringComparison.OrdinalIgnoreCase))
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            RedirectToWwwHelper.SetRedirect(
                context,
                new HostString($"www.{context.HttpContext.Request.Host.Value}"),
                _statusCode);

            context.Logger.RedirectedToWww();
        }
    }
}
