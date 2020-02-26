// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Server.Kestrel.Tests
{
    public class DisposableStack<T> : Stack<T>, IDisposable
        where T : IDisposable
    {
        public void Dispose()
        {
            while (Count > 0)
            {
                Pop()?.Dispose();
            }
        }
    }
}
