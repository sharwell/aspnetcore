// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// <see cref="IApplicationBuilder"/> extension methods for the <see cref="DatabaseErrorPageMiddleware"/>.
    /// </summary>
    public static class DatabaseErrorPageExtensions
    {
        /// <summary>
        /// Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
        /// migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to register the middleware with.</param>
        /// <returns>The same <see cref="IApplicationBuilder"/> instance so that multiple calls can be chained.</returns>
        public static IApplicationBuilder UseDatabaseErrorPage(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseDatabaseErrorPage(new DatabaseErrorPageOptions());
        }

        /// <summary>
        /// Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
        /// migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to register the middleware with.</param>
        /// <param name="options">A <see cref="DatabaseErrorPageOptions"/> that specifies options for the middleware.</param>
        /// <returns>The same <see cref="IApplicationBuilder"/> instance so that multiple calls can be chained.</returns>
        public static IApplicationBuilder UseDatabaseErrorPage(
            this IApplicationBuilder app, DatabaseErrorPageOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            app = app.UseMiddleware<DatabaseErrorPageMiddleware>(Options.Create(options));

            app.UseMigrationsEndPoint(new MigrationsEndPointOptions
            {
                Path = options.MigrationsEndPointPath
            });

            return app;
        }
    }
}