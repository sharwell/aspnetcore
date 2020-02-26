// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;

namespace Microsoft.AspNetCore.Connections
{
    public class ConnectionResetException : IOException
    {
        public ConnectionResetException(string message) : base(message)
        {
        }

        public ConnectionResetException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
