// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Routing.Matching
{
    // End-to-end tests for the HTTP method matching functionality
    public class HttpMethodMatcherPolicyIEndpointSelectorPolicyIntegrationTestBase : HttpMethodMatcherPolicyIntegrationTestBase
    {
        protected override bool HasDynamicMetadata => true;
    }
}
