// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Routing.Patterns;

namespace Microsoft.AspNetCore.Routing.Template
{
    public static class TemplateParser
    {
        public static RouteTemplate Parse(string routeTemplate)
        {
            if (routeTemplate == null)
            {
                throw new ArgumentNullException(routeTemplate);
            }

            try
            {
                var inner = RoutePatternFactory.Parse(routeTemplate);
                return new RouteTemplate(inner);
            }
            catch (RoutePatternException ex)
            {
                // Preserving the existing behavior of this API even though the logic moved.
                throw new ArgumentException(ex.Message, nameof(routeTemplate), ex);
            }
        }
    }
}
