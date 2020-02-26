// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;

namespace Microsoft.AspNetCore.SignalR.Crankier
{
    public interface IAgent
    {
        Task PongAsync(int id, int value);
        Task LogAsync(int id, string text);
        Task StatusAsync(int id, StatusInformation statusInformation);
    }
}
