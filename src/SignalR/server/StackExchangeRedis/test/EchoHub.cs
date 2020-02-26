// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.SignalR.StackExchangeRedis.Tests
{
    public class EchoHub : Hub
    {
        public string Echo(string message)
        {
            return message;
        }

        public Task EchoGroup(string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("Echo", message);
        }

        public Task EchoUser(string userName, string message)
        {
            return Clients.User(userName).SendAsync("Echo", message);
        }

        public Task AddSelfToGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
