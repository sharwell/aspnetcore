// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure
{
    internal class DynamicPageRouteValueTransformerMetadata : IDynamicEndpointMetadata
    {
        public DynamicPageRouteValueTransformerMetadata(Type selectorType)
        {
            if (selectorType == null)
            {
                throw new ArgumentNullException(nameof(selectorType));
            }

            if (!typeof(DynamicRouteValueTransformer).IsAssignableFrom(selectorType))
            {
                throw new ArgumentException(
                    $"The provided type must be a subclass of {typeof(DynamicRouteValueTransformer)}",
                    nameof(selectorType));
            }

            SelectorType = selectorType;
        }

        public bool IsDynamic => true;

        public Type SelectorType { get; }
    }
}
