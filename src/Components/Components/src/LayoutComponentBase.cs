// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Optional base class for components that represent a layout.
    /// Alternatively, components may implement <see cref="IComponent"/> directly
    /// and declare their own parameter named <see cref="Body"/>.
    /// </summary>
    public abstract class LayoutComponentBase : ComponentBase
    {
        internal const string BodyPropertyName = nameof(Body);

        /// <summary>
        /// Gets the content to be rendered inside the layout.
        /// </summary>
        [Parameter]
        public RenderFragment Body { get; set; }
    }
}
