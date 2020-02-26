// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Abstraction that builds conventions that will be used for customization of Hub <see cref="EndpointBuilder"/> instances.
    /// </summary>
    public interface IHubEndpointConventionBuilder : IEndpointConventionBuilder
    {
    }
}
