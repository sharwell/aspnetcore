// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.SignalR.Tests
{
    public static class CancellationTokenExtensions
    {
        public static Task WaitForCancellationAsync(this CancellationToken token)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            token.Register((t) =>
            {
                ((TaskCompletionSource<object>)t).SetResult(null);
            }, tcs);
            return tcs.Task;
        }
    }
}
