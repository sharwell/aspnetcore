// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net.Http;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http3
{
    class Http3StreamErrorException : Exception
    {
        public Http3StreamErrorException(string message, Http3ErrorCode errorCode)
            : base($"HTTP/3 stream error ({errorCode}): {message}")
        {
            ErrorCode = errorCode;
        }

        public Http3ErrorCode ErrorCode { get; }
    }
}
