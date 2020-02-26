// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Routing.Constraints
{
    /// <summary>
    /// Constraints a route parameter that must have a value.
    /// </summary>
    /// <remarks>
    /// This constraint is primarily used to enforce that a non-parameter value is present during
    /// URL generation.
    /// </remarks>
    public class RequiredRouteConstraint : IRouteConstraint
    {
        /// <inheritdoc />
        public bool Match(
            HttpContext httpContext,
            IRouter route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (routeKey == null)
            {
                throw new ArgumentNullException(nameof(routeKey));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.TryGetValue(routeKey, out var value) && value != null)
            {
                // In routing the empty string is equivalent to null, which is equivalent to an unset value.
                var valueString = Convert.ToString(value, CultureInfo.InvariantCulture);
                return !string.IsNullOrEmpty(valueString);
            }

            return false;
        }
    }
}