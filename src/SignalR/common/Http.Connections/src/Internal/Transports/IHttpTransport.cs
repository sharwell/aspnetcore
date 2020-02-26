// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Http.Connections.Internal.Transports
{
    internal interface IHttpTransport
    {
        /// <summary>
        /// Executes the transport
        /// </summary>
        /// <param name="context"></param>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> that completes when the transport has finished processing</returns>
        Task ProcessRequestAsync(HttpContext context, CancellationToken token);
    }
}
