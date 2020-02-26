// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace Microsoft.AspNetCore.StaticFiles
{
    public static class Helpers
    {
        public static string GetAddress(IWebHost server)
        {
            return server.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First();
        }
    }
}
