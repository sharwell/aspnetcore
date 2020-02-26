// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FacebookAuthenticationOptionsExtensions
    {
        public static AuthenticationBuilder AddFacebook(this AuthenticationBuilder builder)
            => builder.AddFacebook(FacebookDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddFacebook(this AuthenticationBuilder builder, Action<FacebookOptions> configureOptions)
            => builder.AddFacebook(FacebookDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddFacebook(this AuthenticationBuilder builder, string authenticationScheme, Action<FacebookOptions> configureOptions)
            => builder.AddFacebook(authenticationScheme, FacebookDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddFacebook(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<FacebookOptions> configureOptions)
            => builder.AddOAuth<FacebookOptions, FacebookHandler>(authenticationScheme, displayName, configureOptions);
    }
}
