// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Microsoft.AspNetCore.Authentication.Test.OpenIdConnect
{
    internal class MockOpenIdConnectMessage : OpenIdConnectMessage
    {
        public string TestAuthorizeEndpoint { get; set; }

        public string TestLogoutRequest { get; set; }

        public override string CreateAuthenticationRequestUrl()
        {
            return TestAuthorizeEndpoint ?? base.CreateAuthenticationRequestUrl();
        }

        public override string CreateLogoutRequestUrl()
        {
            return TestLogoutRequest ?? base.CreateLogoutRequestUrl();
        }
    }
}