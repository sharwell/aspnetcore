// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;

namespace Microsoft.AspNetCore.Routing.Matching
{
    public class RouteEndpointAzureBenchmark : MatcherAzureBenchmarkBase
    {
        [Benchmark]
        public void CreateEndpoints()
        {
            SetupEndpoints();
        }
    }
}