// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.NodeServices
{
    /// <summary>
    /// Supplies INodeServices instances.
    /// </summary>
    [Obsolete("Use Microsoft.AspNetCore.SpaServices.Extensions")]
    public static class NodeServicesFactory
    {
        /// <summary>
        /// Create an <see cref="INodeServices"/> instance according to the supplied options.
        /// </summary>
        /// <param name="options">Options for creating the <see cref="INodeServices"/> instance.</param>
        /// <returns>An <see cref="INodeServices"/> instance.</returns>
        [Obsolete("Use Microsoft.AspNetCore.SpaServices.Extensions")]
        public static INodeServices CreateNodeServices(NodeServicesOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof (options));
            }

            return new NodeServicesImpl(options.NodeInstanceFactory);
        }
    }
}
