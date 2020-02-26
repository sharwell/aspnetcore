// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.DataProtection.Internal
{
    internal class DataProtectionOptionsSetup : IConfigureOptions<DataProtectionOptions>
    {
        private readonly IServiceProvider _services;

        public DataProtectionOptionsSetup(IServiceProvider provider)
        {
            _services = provider;
        }

        public void Configure(DataProtectionOptions options)
        {
            options.ApplicationDiscriminator = _services.GetApplicationUniqueIdentifier();
        }
    }
}
