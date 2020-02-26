﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Routing.Matching
{
    internal abstract class MatcherFactory
    {
        public abstract Matcher CreateMatcher(EndpointDataSource dataSource);
    }
}
