// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.SignalR
{
    public class HubOptionsSetup<THub> : IConfigureOptions<HubOptions<THub>> where THub : Hub
    {
        private readonly HubOptions _hubOptions;
        public HubOptionsSetup(IOptions<HubOptions> options)
        {
            _hubOptions = options.Value;
        }

        public void Configure(HubOptions<THub> options)
        {
            // Do a deep copy, otherwise users modifying the HubOptions<THub> list would be changing the global options list
            options.SupportedProtocols = new List<string>(_hubOptions.SupportedProtocols.Count);
            foreach (var protocol in _hubOptions.SupportedProtocols)
            {
                options.SupportedProtocols.Add(protocol);
            }
            options.KeepAliveInterval = _hubOptions.KeepAliveInterval;
            options.HandshakeTimeout = _hubOptions.HandshakeTimeout;
            options.ClientTimeoutInterval = _hubOptions.ClientTimeoutInterval;
            options.EnableDetailedErrors = _hubOptions.EnableDetailedErrors;
            options.MaximumReceiveMessageSize = _hubOptions.MaximumReceiveMessageSize;
            options.StreamBufferCapacity = _hubOptions.StreamBufferCapacity;

            options.UserHasSetValues = true;
        }
    }
}
