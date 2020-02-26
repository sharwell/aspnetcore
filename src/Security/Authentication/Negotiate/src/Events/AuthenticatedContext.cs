// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication.Negotiate
{
    /// <summary>
    /// State for the Authenticated event.
    /// </summary>
    public class AuthenticatedContext : ResultContext<NegotiateOptions>
    {
        /// <summary>
        /// Creates a new <see cref="AuthenticatedContext"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="scheme"></param>
        /// <param name="options"></param>
        public AuthenticatedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            NegotiateOptions options)
            : base(context, scheme, options) { }
    }
}
