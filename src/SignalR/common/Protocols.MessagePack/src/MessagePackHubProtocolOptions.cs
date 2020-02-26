// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using MessagePack;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Microsoft.AspNetCore.SignalR
{
    public class MessagePackHubProtocolOptions
    {
        private IList<IFormatterResolver> _formatterResolvers;

        public IList<IFormatterResolver> FormatterResolvers
        {
            get
            {
                if (_formatterResolvers == null)
                {
                    // The default set of resolvers trigger a static constructor that throws on AOT environments.
                    // This gives users the chance to use an AOT friendly formatter.
                    _formatterResolvers = MessagePackHubProtocol.CreateDefaultFormatterResolvers();
                }

                return _formatterResolvers;
            }
            set
            {
                _formatterResolvers = value;
            }
        }
    }
}
