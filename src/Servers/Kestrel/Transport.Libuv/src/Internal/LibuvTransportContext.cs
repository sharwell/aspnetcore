// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Hosting;

namespace Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal
{
    internal class LibuvTransportContext
    {
        public LibuvTransportOptions Options { get; set; }

        public IHostApplicationLifetime AppLifetime { get; set; }

        public ILibuvTrace Log { get; set; }
    }
}
