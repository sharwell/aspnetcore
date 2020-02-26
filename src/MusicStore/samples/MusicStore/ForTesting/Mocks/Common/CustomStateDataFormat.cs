// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;

namespace MusicStore.Mocks.Common
{
    public class CustomStateDataFormat : ISecureDataFormat<AuthenticationProperties>
    {
        private static string _lastSavedAuthenticationProperties;

        public string Protect(AuthenticationProperties data, string purose)
        {
            return Protect(data);
        }

        public string Protect(AuthenticationProperties data)
        {
            _lastSavedAuthenticationProperties = Serialize(data);
            return "ValidStateData";
        }

        public AuthenticationProperties Unprotect(string state, string purpose)
        {
            return Unprotect(state);
        }

        public AuthenticationProperties Unprotect(string state)
        {
            return state == "ValidStateData" ? DeSerialize(_lastSavedAuthenticationProperties) : null;
        }

        private string Serialize(AuthenticationProperties data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        private AuthenticationProperties DeSerialize(string state)
        {
            return JsonConvert.DeserializeObject<AuthenticationProperties>(state);
        }
    }
} 
