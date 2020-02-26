// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XmlFormattersWebSite
{
    public class Store
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}