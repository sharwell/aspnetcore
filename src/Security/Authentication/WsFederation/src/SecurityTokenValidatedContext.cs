// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.WsFederation;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.AspNetCore.Authentication.WsFederation
{
    /// <summary>
    /// The context object used for <see cref="WsFederationEvents.SecurityTokenValidated"/>.
    /// </summary>
    public class SecurityTokenValidatedContext : RemoteAuthenticationContext<WsFederationOptions>
    {
        /// <summary>
        /// Creates a <see cref="SecurityTokenValidatedContext"/>
        /// </summary>
        public SecurityTokenValidatedContext(HttpContext context, AuthenticationScheme scheme, WsFederationOptions options, ClaimsPrincipal principal, AuthenticationProperties properties)
            : base(context, scheme, options, properties)
            => Principal = principal;

        /// <summary>
        /// The <see cref="WsFederationMessage"/> received on this request.
        /// </summary>
        public WsFederationMessage ProtocolMessage { get; set; }

        /// <summary>
        /// The <see cref="SecurityToken"/> that was validated.
        /// </summary>
        public SecurityToken SecurityToken { get; set; }
    }
}