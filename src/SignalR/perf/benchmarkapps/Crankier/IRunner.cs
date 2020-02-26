// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;

namespace Microsoft.AspNetCore.SignalR.Crankier
{
    public interface IRunner
    {
        Task PongWorkerAsync(int workerId, int value);

        Task LogAgentAsync(string format, params object[] arguments);

        Task LogWorkerAsync(int workerId, string format, params object[] arguments);
    }
}
