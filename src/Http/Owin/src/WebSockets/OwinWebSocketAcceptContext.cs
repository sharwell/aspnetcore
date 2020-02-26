// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Owin
{
    public class OwinWebSocketAcceptContext : WebSocketAcceptContext
    {
        private IDictionary<string, object> _options;

        public OwinWebSocketAcceptContext() : this(new Dictionary<string, object>(1))
        {
        }

        public OwinWebSocketAcceptContext(IDictionary<string, object> options)
        {
            _options = options;
        }

        public override string SubProtocol
        {
            get
            {
                object obj;
                if (_options != null && _options.TryGetValue(OwinConstants.WebSocket.SubProtocol, out obj))
                {
                    return (string)obj;
                }
                return null;
            }
            set
            {
                if (_options == null)
                {
                    _options = new Dictionary<string, object>(1);
                }
                _options[OwinConstants.WebSocket.SubProtocol] = value;
            }
        }

        public IDictionary<string, object> Options
        {
            get { return _options; }
        }
    }
}