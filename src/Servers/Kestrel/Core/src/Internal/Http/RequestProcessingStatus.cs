// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http
{
    internal enum RequestProcessingStatus
    {
        RequestPending,
        ParsingRequestLine,
        ParsingHeaders,
        AppStarted,
        HeadersCommitted,
        HeadersFlushed,
        ResponseCompleted
    }
}
