// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Describes information determined during routing that specifies
    /// the page to be displayed.
    /// </summary>
    public sealed class RouteData
    {
        /// <summary>
        /// Constructs an instance of <see cref="RouteData"/>.
        /// </summary>
        /// <param name="pageType">The type of the page matching the route, which must implement <see cref="IComponent"/>.</param>
        /// <param name="routeValues">The route parameter values extracted from the matched route.</param>
        public RouteData(Type pageType, IReadOnlyDictionary<string, object> routeValues)
        {
            if (pageType == null)
            {
                throw new ArgumentNullException(nameof(pageType));
            }

            if (!typeof(IComponent).IsAssignableFrom(pageType))
            {
                throw new ArgumentException($"The value must implement {nameof(IComponent)}.", nameof(pageType));
            }

            PageType = pageType;
            RouteValues = routeValues ?? throw new ArgumentNullException(nameof(routeValues));
        }

        /// <summary>
        /// Gets the type of the page matching the route.
        /// </summary>
        public Type PageType { get; }

        /// <summary>
        /// Gets route parameter values extracted from the matched route.
        /// </summary>
        public IReadOnlyDictionary<string, object> RouteValues { get; }
    }
}
