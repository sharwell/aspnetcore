// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.SpaServices.Webpack
{
    [Obsolete("Use Microsoft.AspNetCore.SpaServices.Extensions")]
    internal class ConditionalProxyMiddlewareOptions
    {
        public ConditionalProxyMiddlewareOptions(string scheme, string host, string port, TimeSpan requestTimeout)
        {
            Scheme = scheme;
            Host = host;
            Port = port;
            RequestTimeout = requestTimeout;
        }

        public string Scheme { get; }
        public string Host { get; }
        public string Port { get; }
        public TimeSpan RequestTimeout { get; }
    }
}
