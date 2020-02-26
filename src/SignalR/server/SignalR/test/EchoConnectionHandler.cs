// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Buffers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;

namespace Microsoft.AspNetCore.SignalR.Tests
{
    public class EchoConnectionHandler : ConnectionHandler
    {
        public override async Task OnConnectedAsync(ConnectionContext connection)
        {
            while (true)
            {
                var result = await connection.Transport.Input.ReadAsync();
                var buffer = result.Buffer;

                if (!buffer.IsEmpty)
                {
                    await connection.Transport.Output.WriteAsync(buffer.ToArray());
                }
                else if (result.IsCompleted)
                {
                    break;
                }

                connection.Transport.Input.AdvanceTo(buffer.End);
            }
        }
    }
}
