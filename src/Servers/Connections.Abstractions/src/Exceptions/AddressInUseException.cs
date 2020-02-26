﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Connections
{
    public class AddressInUseException : InvalidOperationException
    {
        public AddressInUseException(string message) : base(message)
        {
        }

        public AddressInUseException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
