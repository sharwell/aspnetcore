// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text;

namespace Microsoft.AspNetCore.HttpSys.Internal
{
    internal static class HeaderEncoding
    {
        // It should just be ASCII or ANSI, but they break badly with un-expected values. We use UTF-8 because it's the same for
        // ASCII, and because some old client would send UTF8 Host headers and expect UTF8 Location responses
        // (e.g. IE and HttpWebRequest on intranets).
        private static Encoding Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: false);

        internal static unsafe string GetString(byte* pBytes, int byteCount)
        {
            return Encoding.GetString(new ReadOnlySpan<byte>(pBytes, byteCount));
        }

        internal static byte[] GetBytes(string myString)
        {
            return Encoding.GetBytes(myString);
        }
    }
}
