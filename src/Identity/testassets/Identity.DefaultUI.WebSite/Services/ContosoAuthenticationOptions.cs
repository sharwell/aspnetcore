// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication;

namespace Identity.DefaultUI.WebSite
{
    public class ContosoAuthenticationOptions : AuthenticationSchemeOptions
    {
        public ContosoAuthenticationOptions()
        {
            Events = new object();
        }

        public string SignInScheme { get; set; }
        public string ReturnUrlQueryParameter { get; set; } = "returnUrl";
        public string RemoteLoginPath { get; set; } = "/Contoso/Login";
    }
}