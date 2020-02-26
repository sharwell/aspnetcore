// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication;

namespace MusicStore.Mocks.OpenIdConnect
{
    internal class CustomStringDataFormat : ISecureDataFormat<string>
    {
        private const string _capturedNonce = "635579928639517715.OTRjOTVkM2EtMDRmYS00ZDE3LThhZGUtZWZmZGM4ODkzZGZkMDRlNDhkN2MtOWIwMC00ZmVkLWI5MTItMTUwYmQ4MzdmOWI0";

        public string Protect(string data)
        {
            return "protectedString";
        }

        public string Protect(string data, string purpose)
        {
            return purpose + "protectedString";
        }

        public string Unprotect(string protectedText)
        {
            return protectedText == "protectedString" ? _capturedNonce : null;
        }

        public string Unprotect(string protectedText, string purpose)
        {
            return protectedText == (purpose + "protectedString") ? _capturedNonce : null;
        }
    }
}
