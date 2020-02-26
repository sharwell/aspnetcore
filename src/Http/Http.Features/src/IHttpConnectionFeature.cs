// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;

namespace Microsoft.AspNetCore.Http.Features
{
    /// <summary>
    /// Information regarding the TCP/IP connection carrying the request.
    /// </summary>
    public interface IHttpConnectionFeature
    {
        /// <summary>
        /// The unique identifier for the connection the request was received on. This is primarily for diagnostic purposes.
        /// </summary>
        string ConnectionId { get; set; }

        /// <summary>
        /// The IPAddress of the client making the request. Note this may be for a proxy rather than the end user.
        /// </summary>
        IPAddress RemoteIpAddress { get; set; }

        /// <summary>
        /// The local IPAddress on which the request was received.
        /// </summary>
        IPAddress LocalIpAddress { get; set; }

        /// <summary>
        /// The remote port of the client making the request.
        /// </summary>
        int RemotePort { get; set; }

        /// <summary>
        /// The local port on which the request was received.
        /// </summary>
        int LocalPort { get; set; }
    }
}