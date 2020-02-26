// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication
{
    public class HandleRequestContext<TOptions> : BaseContext<TOptions> where TOptions : AuthenticationSchemeOptions
    {
        protected HandleRequestContext(
            HttpContext context,
            AuthenticationScheme scheme,
            TOptions options)
            : base(context, scheme, options) { }

        /// <summary>
        /// The <see cref="HandleRequestResult"/> which is used by the handler.
        /// </summary>
        public HandleRequestResult Result { get; protected set; }

        /// <summary>
        /// Discontinue all processing for this request and return to the client.
        /// The caller is responsible for generating the full response.
        /// </summary>
        public void HandleResponse() => Result = HandleRequestResult.Handle();

        /// <summary>
        /// Discontinue processing the request in the current handler.
        /// </summary>
        public void SkipHandler() => Result = HandleRequestResult.SkipHandler();
    }
}