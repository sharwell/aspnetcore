﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Microsoft.AspNetCore.DataProtection
{
    internal class RegistryPolicy
    {
        public RegistryPolicy(
            AlgorithmConfiguration configuration,
            IEnumerable<IKeyEscrowSink> keyEscrowSinks,
            int? defaultKeyLifetime)
        {
            EncryptorConfiguration = configuration;
            KeyEscrowSinks = keyEscrowSinks;
            DefaultKeyLifetime = defaultKeyLifetime;
        }

        public AlgorithmConfiguration EncryptorConfiguration { get; }

        public IEnumerable<IKeyEscrowSink> KeyEscrowSinks { get; }

        public int? DefaultKeyLifetime { get; }
    }
}
