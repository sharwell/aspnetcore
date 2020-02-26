// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Microsoft.AspNetCore.Authentication.OpenIdConnect
{
    public class RemoteSignOutContext : RemoteAuthenticationContext<OpenIdConnectOptions>
    {
        public RemoteSignOutContext(HttpContext context, AuthenticationScheme scheme, OpenIdConnectOptions options, OpenIdConnectMessage message)
            : base(context, scheme, options, new AuthenticationProperties())
            => ProtocolMessage = message;

        public OpenIdConnectMessage ProtocolMessage { get; set; }
    }
}