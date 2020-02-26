// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.AspNetCore.Testing;

namespace Microsoft.AspNetCore.Server.Kestrel.InMemory.FunctionalTests.TestTransport
{
    internal class InMemoryConnection : StreamBackedTestConnection
    {
        public InMemoryConnection(InMemoryTransportConnection transportConnection)
            : base(new DuplexPipeStream(transportConnection.Output, transportConnection.Input))
        {
            TransportConnection = transportConnection;
        }

        public InMemoryTransportConnection TransportConnection { get; }

        public override void Reset()
        {
            TransportConnection.Input.Complete(new ConnectionResetException(string.Empty));
            TransportConnection.OnClosed();
        }

        public override void ShutdownSend()
        {
            TransportConnection.Input.Complete();
            TransportConnection.OnClosed();
        }

        public override void Dispose()
        {
            TransportConnection.Input.Complete();
            TransportConnection.Output.Complete();
            TransportConnection.OnClosed();
            base.Dispose();
        }
    }
}
