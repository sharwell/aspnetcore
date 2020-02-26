// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Primitives;

namespace Microsoft.AspNetCore.ResponseCaching
{
    internal class CachedVaryByRules : IResponseCacheEntry
    {
        public string VaryByKeyPrefix { get; set; }

        public StringValues Headers { get; set; }

        public StringValues QueryKeys { get; set; }
    }
}
