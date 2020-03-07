// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Builds conventions that will be used for customization of ComponentHub <see cref="EndpointBuilder"/> instances.
    /// </summary>
    public sealed class ComponentEndpointConventionBuilder : IHubEndpointConventionBuilder
    {
        private readonly IEndpointConventionBuilder _hubEndpoint;
        private readonly IEndpointConventionBuilder _disconnectEndpoint;

        internal ComponentEndpointConventionBuilder(IEndpointConventionBuilder hubEndpoint, IEndpointConventionBuilder disconnectEndpoint)
        {
            _hubEndpoint = hubEndpoint;
            _disconnectEndpoint = disconnectEndpoint;
        }

        /// <summary>
        /// Adds the specified convention to the builder. Conventions are used to customize <see cref="EndpointBuilder"/> instances.
        /// </summary>
        /// <param name="convention">The convention to add to the builder.</param>
        public void Add(Action<EndpointBuilder> convention)
        {
            _hubEndpoint.Add(convention);
            _disconnectEndpoint.Add(convention);
        }
    }
}
