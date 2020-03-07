// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Diagnostics
{
    public class ExceptionHandlerFeature : IExceptionHandlerPathFeature
    {
        public Exception Error { get; set; }

        public string Path { get; set; }
    }
}