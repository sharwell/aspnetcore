// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Routing.Template;

namespace Microsoft.AspNetCore.Routing.Tree
{
    /// <summary>
    /// A candidate match for link generation in a <see cref="TreeRouter"/>.
    /// </summary>
    public class OutboundMatch
    {
        /// <summary>
        /// Gets or sets the <see cref="OutboundRouteEntry"/>.
        /// </summary>
        public OutboundRouteEntry Entry { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TemplateBinder"/>.
        /// </summary>
        public TemplateBinder TemplateBinder { get; set; }
    }
}
