// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Microsoft.AspNetCore.Authentication.OpenIdConnect
{
    /// <summary>
    /// When a user configures the <see cref="OpenIdConnectHandler"/> to be notified prior to redirecting to an IdentityProvider
    /// an instance of <see cref="RedirectContext"/> is passed to the 'RedirectToAuthenticationEndpoint' or 'RedirectToEndSessionEndpoint' events.
    /// </summary>
    public class RedirectContext : PropertiesContext<OpenIdConnectOptions>
    {
        public RedirectContext(
            HttpContext context,
            AuthenticationScheme scheme,
            OpenIdConnectOptions options,
            AuthenticationProperties properties)
            : base(context, scheme, options, properties) { }

        public OpenIdConnectMessage ProtocolMessage { get; set; }

        /// <summary>
        /// If true, will skip any default logic for this redirect.
        /// </summary>
        public bool Handled { get; private set; }

        /// <summary>
        /// Skips any default logic for this redirect.
        /// </summary>
        public void HandleResponse() => Handled = true;
    }
}