// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Routing.Matching
{
    public class RouteMatcherConformanceTest : FullFeaturedMatcherConformanceTest
    {
        internal override Matcher CreateMatcher(params RouteEndpoint[] endpoints)
        {
            var builder = new RouteMatcherBuilder();
            for (var i = 0; i < endpoints.Length; i++)
            {
                builder.AddEndpoint(endpoints[i]); 
            }
            return builder.Build();
        }
    }
}
