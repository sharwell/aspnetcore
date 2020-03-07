﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Diagnostics
{
    /// <summary>
    /// Represents an exception handler with the original path of the request.
    /// </summary>
    public interface IExceptionHandlerPathFeature : IExceptionHandlerFeature
    {
        /// <summary>
        /// The portion of the request path that identifies the requested resource. The value
        /// is un-escaped.
        /// </summary>
        string Path { get; }
    }
}
