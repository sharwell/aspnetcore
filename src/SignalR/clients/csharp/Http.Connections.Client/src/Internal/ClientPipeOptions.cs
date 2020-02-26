// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO.Pipelines;

namespace Microsoft.AspNetCore.Http.Connections.Client.Internal
{
    internal static class ClientPipeOptions
    {
        public static PipeOptions DefaultOptions = new PipeOptions(writerScheduler: PipeScheduler.ThreadPool, readerScheduler: PipeScheduler.ThreadPool, useSynchronizationContext: false, pauseWriterThreshold: 0, resumeWriterThreshold: 0);
    }
}
