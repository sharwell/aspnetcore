// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Server.Kestrel.Core
{
    internal sealed class AnyIPListenOptions : ListenOptions
    {
        internal AnyIPListenOptions(int port)
            : base(new IPEndPoint(IPAddress.IPv6Any, port))
        {
        }

        internal override async Task BindAsync(AddressBindContext context)
        {
            // when address is 'http://hostname:port', 'http://*:port', or 'http://+:port'
            try
            {
                await base.BindAsync(context).ConfigureAwait(false);
            }
            catch (Exception ex) when (!(ex is IOException))
            {
                context.Logger.LogDebug(CoreStrings.FormatFallbackToIPv4Any(IPEndPoint.Port));

                // for machines that do not support IPv6
                EndPoint = new IPEndPoint(IPAddress.Any, IPEndPoint.Port);
                await base.BindAsync(context).ConfigureAwait(false);
            }
        }
    }
}
