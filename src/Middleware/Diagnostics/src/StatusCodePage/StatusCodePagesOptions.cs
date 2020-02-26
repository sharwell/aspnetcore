// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Options for StatusCodePagesMiddleware.
    /// </summary>
    public class StatusCodePagesOptions
    {
        public StatusCodePagesOptions()
        {
            HandleAsync = context =>
            {
                // TODO: Render with a pre-compiled html razor view.
                var statusCode = context.HttpContext.Response.StatusCode;

                var body = BuildResponseBody(statusCode);

                context.HttpContext.Response.ContentType = "text/plain";
                return context.HttpContext.Response.WriteAsync(body);
            };
        }

        private string BuildResponseBody(int httpStatusCode)
        {
            // Note the 500 spaces are to work around an IE 'feature'
            var internetExplorerWorkaround = new string(' ', 500);

            var reasonPhrase = ReasonPhrases.GetReasonPhrase(httpStatusCode);

            return string.Format(CultureInfo.InvariantCulture, "Status Code: {0}{1}{2}{3}",
                                                                    httpStatusCode,
                                                                    string.IsNullOrWhiteSpace(reasonPhrase) ? "" : "; ",
                                                                    reasonPhrase,
                                                                    internetExplorerWorkaround);
        }

        public Func<StatusCodeContext, Task> HandleAsync { get; set; }
    }
}