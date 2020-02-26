// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace Microsoft.AspNetCore.Mvc.IntegrationTests
{
    public class ProductDetails
    {
        [Required]
        public string Detail1 { get; set; }

        [Required]
        public string Detail2 { get; set; }

        [Required]
        public string Detail3 { get; set; }
    }
}
