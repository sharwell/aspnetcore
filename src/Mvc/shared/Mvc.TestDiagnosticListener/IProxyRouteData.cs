// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public interface IProxyRouteData
    {
        IReadOnlyList<object> Routers { get; }
        IDictionary<string, object> DataTokens { get; }
        IDictionary<string, object> Values { get; }
    }
}
