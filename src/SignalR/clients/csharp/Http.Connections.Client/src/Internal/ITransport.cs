// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;

namespace Microsoft.AspNetCore.Http.Connections.Client.Internal
{
    internal interface ITransport : IDuplexPipe
    {
        Task StartAsync(Uri url, TransferFormat transferFormat, CancellationToken cancellationToken = default);
        Task StopAsync();
    }
}
