// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Components.Builder
{
    /// <summary>
    /// A builder for adding components to an application.
    /// </summary>
    public interface IComponentsApplicationBuilder
    {
        /// <summary>
        /// Gets the application services.
        /// </summary>
        IServiceProvider Services { get; }

        /// <summary>
        /// Associates the <see cref="IComponent"/> with the application,
        /// causing it to be displayed in the specified DOM element.
        /// </summary>
        /// <param name="componentType">The type of the component.</param>
        /// <param name="domElementSelector">A CSS selector that uniquely identifies a DOM element.</param>
        void AddComponent(Type componentType, string domElementSelector);
    }
}
