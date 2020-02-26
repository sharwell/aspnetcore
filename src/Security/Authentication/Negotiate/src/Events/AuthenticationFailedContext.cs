// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication.Negotiate
{
    /// <summary>
    /// State for the AuthenticationFailed event.
    /// </summary>
    public class AuthenticationFailedContext : RemoteAuthenticationContext<NegotiateOptions>
    {
        /// <summary>
        /// Creates a <see cref="AuthenticationFailedContext"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="scheme"></param>
        /// <param name="options"></param>
        public AuthenticationFailedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            NegotiateOptions options)
            : base(context, scheme, options, properties: null) { }

        /// <summary>
        /// The exception that occurred while processing the authentication.
        /// </summary>
        public Exception Exception { get; set; }
    }
}
