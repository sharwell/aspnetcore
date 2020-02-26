// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;

namespace Microsoft.AspNetCore.SignalR.Tests
{
    internal class CancellationDisposable : IDisposable
    {
        private readonly CancellationTokenSource _cts;

        public CancellationDisposable(CancellationTokenSource cts)
        {
            _cts = cts;
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}
