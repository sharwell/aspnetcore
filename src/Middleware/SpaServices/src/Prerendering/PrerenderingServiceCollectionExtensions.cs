// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.SpaServices.Prerendering;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up prerendering features in an <see cref="IServiceCollection" />.
    /// </summary>
    [Obsolete("Use Microsoft.AspNetCore.SpaServices.Extensions")]
    public static class PrerenderingServiceCollectionExtensions
    {
        /// <summary>
        /// Configures the dependency injection system to supply an implementation
        /// of <see cref="ISpaPrerenderer"/>.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/>.</param>
        [Obsolete("Use Microsoft.AspNetCore.SpaServices.Extensions")]
        public static void AddSpaPrerenderer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddSingleton<ISpaPrerenderer, DefaultSpaPrerenderer>();
        }
    }
}
