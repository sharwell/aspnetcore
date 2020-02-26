// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.SpaServices
{
    [Obsolete("Use Microsoft.AspNetCore.SpaServices.Extensions")]
    internal class SpaRouteConstraint : IRouteConstraint
    {
        private readonly string _clientRouteTokenName;

        public SpaRouteConstraint(string clientRouteTokenName)
        {
            if (string.IsNullOrEmpty(clientRouteTokenName))
            {
                throw new ArgumentException("Value cannot be null or empty", nameof(clientRouteTokenName));
            }

            _clientRouteTokenName = clientRouteTokenName;
        }

        public bool Match(
            HttpContext httpContext,
            IRouter route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return !HasDotInLastSegment(values[_clientRouteTokenName] as string ?? string.Empty);
        }

        private bool HasDotInLastSegment(string uri)
        {
            var lastSegmentStartPos = uri.LastIndexOf('/');
            return uri.IndexOf('.', lastSegmentStartPos + 1) >= 0;
        }
    }
}
