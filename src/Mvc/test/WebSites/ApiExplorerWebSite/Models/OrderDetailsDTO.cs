// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace ApiExplorerWebSite
{
    public class OrderDetailsDTO
    {
        [FromForm]
        public int Quantity { get; set; }

        [FromForm]
        public Product Product { get; set; }
    }
}