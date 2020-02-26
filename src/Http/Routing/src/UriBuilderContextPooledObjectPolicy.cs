// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Encodings.Web;
using Microsoft.Extensions.ObjectPool;

namespace Microsoft.AspNetCore.Routing
{
    internal class UriBuilderContextPooledObjectPolicy : IPooledObjectPolicy<UriBuildingContext>
    {
        public UriBuildingContext Create()
        {
            return new UriBuildingContext(UrlEncoder.Default);
        }

        public bool Return(UriBuildingContext obj)
        {
            obj.Clear();
            return true;
        }
    }
}
