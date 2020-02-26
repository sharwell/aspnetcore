// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace VersioningWebSite
{
    public class RoutingController : Controller
    {
        public bool HasEndpointMatch()
        {
            var endpointFeature = HttpContext.Features.Get<IEndpointFeature>();
            return endpointFeature?.Endpoint != null;
        }
    }
}