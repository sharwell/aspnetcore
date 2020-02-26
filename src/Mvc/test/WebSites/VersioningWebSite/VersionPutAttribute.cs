// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Routing;

namespace VersioningWebSite
{
    public class VersionPutAttribute : VersionRouteAttribute, IActionHttpMethodProvider
    {
        public VersionPutAttribute(string template)
            : base(template)
        {
        }

        public VersionPutAttribute(string template, string versionRange)
            : base(template, versionRange)
        {
        }

        private readonly IEnumerable<string> _httpMethods = new[] { "PUT" };

        public IEnumerable<string> HttpMethods
        {
            get
            {
                return _httpMethods;
            }
        }
    }
}