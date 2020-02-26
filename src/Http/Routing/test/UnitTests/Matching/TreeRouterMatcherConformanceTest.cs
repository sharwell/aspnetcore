// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Xunit;

namespace Microsoft.AspNetCore.Routing.Matching
{
    public class TreeRouterMatcherConformanceTest : FullFeaturedMatcherConformanceTest
    {
        // TreeRouter doesn't support non-inline default values.
        [Fact]
        public override Task Match_NonInlineDefaultValues()
        {
            return Task.CompletedTask;
        }

        // TreeRouter doesn't support non-inline default values.
        [Fact]
        public override Task Match_ExtraDefaultValues()
        {
            return Task.CompletedTask;
        }

        internal override Matcher CreateMatcher(params RouteEndpoint[] endpoints)
        {
            var builder = new TreeRouterMatcherBuilder();
            for (var i = 0; i < endpoints.Length; i++)
            {
                builder.AddEndpoint(endpoints[i]);
            }
            return builder.Build();
        }
    }
}
