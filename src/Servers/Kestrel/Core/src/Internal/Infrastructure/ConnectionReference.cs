// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure
{
    internal class ConnectionReference
    {
        private readonly WeakReference<KestrelConnection> _weakReference;

        public ConnectionReference(KestrelConnection connection)
        {
            _weakReference = new WeakReference<KestrelConnection>(connection);
            ConnectionId = connection.GetTransport().ConnectionId;
        }

        public string ConnectionId { get; }

        public bool TryGetConnection(out KestrelConnection connection)
        {
            return _weakReference.TryGetTarget(out connection);
        }
    }
}
