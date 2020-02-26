// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Server.Kestrel.Transport.Quic.Internal
{
    internal interface IQuicTrace : ILogger
    {
        void NewConnection(string connectionId);
        void NewStream(string streamId);
        void ConnectionError(string connectionId, Exception ex);
        void StreamError(string streamId, Exception ex);
        void StreamPause(string streamId);
        void StreamResume(string streamId);
        void StreamShutdownWrite(string streamId, Exception ex);
        void StreamAbort(string streamId, Exception ex);
    }
}
