// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Authentication.Google
{
    /// <summary>
    /// Default values for Google authentication
    /// </summary>
    public static class GoogleDefaults
    {
        public const string AuthenticationScheme = "Google";

        public static readonly string DisplayName = "Google";

        // https://developers.google.com/identity/protocols/OAuth2WebServer
        public static readonly string AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";

        public static readonly string TokenEndpoint = "https://www.googleapis.com/oauth2/v4/token";

        // https://developers.google.com/apis-explorer/#search/oauth2/oauth2/v2/
        public static readonly string UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
    }
}
