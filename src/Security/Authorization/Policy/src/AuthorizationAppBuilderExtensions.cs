// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add authorization capabilities to an HTTP application pipeline.
    /// </summary>
    public static class AuthorizationAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="AuthorizationMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables authorization capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseAuthorization(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            VerifyServicesRegistered(app);

            return app.UseMiddleware<AuthorizationMiddleware>();
        }

        private static void VerifyServicesRegistered(IApplicationBuilder app)
        {
            // Verify that AddAuthorizationPolicy was called before calling UseAuthorization
            // We use the AuthorizationPolicyMarkerService to ensure all the services were added.
            if (app.ApplicationServices.GetService(typeof(AuthorizationPolicyMarkerService)) == null)
            {
                throw new InvalidOperationException(Resources.FormatException_UnableToFindServices(
                    nameof(IServiceCollection),
                    nameof(PolicyServiceCollectionExtensions.AddAuthorization),
                    "ConfigureServices(...)"));
            }
        }
    }
}
