﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal
{
    [Serializable]
    internal class Http3ConnectionException : Exception
    {
        public Http3ConnectionException()
        {
        }

        public Http3ConnectionException(string message) : base(message)
        {
        }

        public Http3ConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Http3ConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}