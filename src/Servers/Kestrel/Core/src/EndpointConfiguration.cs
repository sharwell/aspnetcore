// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Server.Kestrel
{
    public class EndpointConfiguration
    {
        internal EndpointConfiguration(bool isHttps, ListenOptions listenOptions, HttpsConnectionAdapterOptions httpsOptions, IConfigurationSection configSection)
        {
            IsHttps = isHttps;
            ListenOptions = listenOptions ?? throw new ArgumentNullException(nameof(listenOptions));
            HttpsOptions = httpsOptions ?? throw new ArgumentNullException(nameof(httpsOptions));
            ConfigSection = configSection ?? throw new ArgumentNullException(nameof(configSection));
        }

        public bool IsHttps { get; }
        public ListenOptions ListenOptions { get; }
        public HttpsConnectionAdapterOptions HttpsOptions { get; }
        public IConfigurationSection ConfigSection { get; }
    }
}
