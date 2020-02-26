// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Http.Connections.Client
{
    /// <summary>
    /// Exception thrown during negotiate when there are no supported transports between the client and server.
    /// </summary>
    public class NoTransportSupportedException : Exception
    {
        public NoTransportSupportedException(string message)
            : base(message)
        {
        }
    }
}
