// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.JSInterop.Infrastructure;

namespace Microsoft.JSInterop
{
    internal class TestJSRuntime : JSRuntime
    {
        protected override void BeginInvokeJS(long asyncHandle, string identifier, string argsJson)
        {
            throw new NotImplementedException();
        }

        protected internal override void EndInvokeDotNet(DotNetInvocationInfo invocationInfo, in DotNetInvocationResult invocationResult)
        {
            throw new NotImplementedException();
        }
    }
}
