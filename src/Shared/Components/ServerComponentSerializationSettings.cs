// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text.Json;

namespace Microsoft.AspNetCore.Components
{
    internal static class ServerComponentSerializationSettings
    {
        public const string DataProtectionProviderPurpose = "Microsoft.AspNetCore.Components.ComponentDescriptorSerializer,V1";

        public static readonly JsonSerializerOptions JsonSerializationOptions =
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true
            };

        // This setting is not configurable, but realistically we don't expect an app to take more than 30 seconds from when
        // it got rendrered to when the circuit got started, and having an expiration on the serialized server-components helps
        // prevent old payloads from being replayed.
        public static readonly TimeSpan DataExpiration = TimeSpan.FromMinutes(5);
    }
}
