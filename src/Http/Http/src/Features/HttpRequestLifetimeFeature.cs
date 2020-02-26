// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;

namespace Microsoft.AspNetCore.Http.Features
{
    public class HttpRequestLifetimeFeature : IHttpRequestLifetimeFeature
    {
        public CancellationToken RequestAborted { get; set; }

        public void Abort()
        {
        }
    }
}