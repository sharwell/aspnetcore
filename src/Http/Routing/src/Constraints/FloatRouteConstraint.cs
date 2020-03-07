// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Routing.Constraints
{
    /// <summary>
    /// Constrains a route parameter to represent only 32-bit floating-point values.
    /// </summary>
    public class FloatRouteConstraint : IRouteConstraint
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
                if (value is float)
                {
                    return true;
                }

                var valueString = Convert.ToString(value, CultureInfo.InvariantCulture);
                return float.TryParse(
                    valueString,
                    NumberStyles.Float | NumberStyles.AllowThousands,
                    CultureInfo.InvariantCulture,
                    out _);
            }

            return false;
        }
    }
}