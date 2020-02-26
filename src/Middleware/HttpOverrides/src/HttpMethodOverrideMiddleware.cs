// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.HttpOverrides
{
    public class HttpMethodOverrideMiddleware
    {
        private const string xHttpMethodOverride = "X-Http-Method-Override";
        private readonly RequestDelegate _next;
        private readonly HttpMethodOverrideOptions _options;

        public HttpMethodOverrideMiddleware(RequestDelegate next, IOptions<HttpMethodOverrideOptions> options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (HttpMethods.IsPost(context.Request.Method))
            {
                if (_options.FormFieldName != null)
                {
                    if (context.Request.HasFormContentType)
                    {
                        var form = await context.Request.ReadFormAsync();
                        var methodType = form[_options.FormFieldName];
                        if (!string.IsNullOrEmpty(methodType))
                        {
                            context.Request.Method = methodType;
                        }
                    }
                }
                else
                {
                    var xHttpMethodOverrideValue = context.Request.Headers[xHttpMethodOverride];
                    if (!string.IsNullOrEmpty(xHttpMethodOverrideValue))
                    {
                        context.Request.Method = xHttpMethodOverrideValue;
                    }
                }
            }
            await _next(context);
        }
    }
}
