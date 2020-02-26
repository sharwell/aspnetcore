// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.NodeServices.HostingModels
{
    /// <summary>
    /// Extension methods that help with populating a <see cref="NodeServicesOptions"/> object.
    /// </summary>
    [Obsolete("Use Microsoft.AspNetCore.SpaServices.Extensions")]
    public static class NodeServicesOptionsExtensions
    {
        /// <summary>
        /// Configures the <see cref="INodeServices"/> service so that it will use out-of-process
        /// Node.js instances and perform RPC calls over HTTP.
        /// </summary>
        [Obsolete("Use Microsoft.AspNetCore.SpaServices.Extensions")]
        public static void UseHttpHosting(this NodeServicesOptions options)
        {
            options.NodeInstanceFactory = () => new HttpNodeInstance(options);
        }
    }
}
