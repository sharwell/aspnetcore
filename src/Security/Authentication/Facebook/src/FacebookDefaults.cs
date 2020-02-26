// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Authentication.Facebook
{
    public static class FacebookDefaults
    {
        public const string AuthenticationScheme = "Facebook";

        public static readonly string DisplayName = "Facebook";

        // https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow#login
        public static readonly string AuthorizationEndpoint = "https://www.facebook.com/v4.0/dialog/oauth";

        public static readonly string TokenEndpoint = "https://graph.facebook.com/v4.0/oauth/access_token";

        public static readonly string UserInformationEndpoint = "https://graph.facebook.com/v4.0/me";
    }
}
