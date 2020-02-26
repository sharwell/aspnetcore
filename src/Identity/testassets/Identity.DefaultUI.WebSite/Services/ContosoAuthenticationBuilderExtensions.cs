// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Authentication;

namespace Identity.DefaultUI.WebSite
{
    public static class ContosoAuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddContosoAuthentication(
            this AuthenticationBuilder builder,
            Action<ContosoAuthenticationOptions> configure) =>
                builder.AddScheme<ContosoAuthenticationOptions, ContosoAuthenticationHandler>(
                    ContosoAuthenticationConstants.Scheme,
                    ContosoAuthenticationConstants.DisplayName,
                    configure);
    }
}
