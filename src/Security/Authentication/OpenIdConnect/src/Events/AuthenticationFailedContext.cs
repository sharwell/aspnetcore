// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Microsoft.AspNetCore.Authentication.OpenIdConnect
{
    public class AuthenticationFailedContext : RemoteAuthenticationContext<OpenIdConnectOptions>
    {
        public AuthenticationFailedContext(HttpContext context, AuthenticationScheme scheme, OpenIdConnectOptions options)
            : base(context, scheme, options, new AuthenticationProperties())
        { }

        public OpenIdConnectMessage ProtocolMessage { get; set; }

        public Exception Exception { get; set; }
    }
}