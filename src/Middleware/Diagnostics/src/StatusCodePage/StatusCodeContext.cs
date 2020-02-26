// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Diagnostics
{
    public class StatusCodeContext
    {
        public StatusCodeContext(HttpContext context, StatusCodePagesOptions options, RequestDelegate next)
        {
            HttpContext = context;
            Options = options;
            Next = next;
        }

        public HttpContext HttpContext { get; private set; }

        public StatusCodePagesOptions Options { get; private set; }

        public RequestDelegate Next { get; private set; }
    }
}