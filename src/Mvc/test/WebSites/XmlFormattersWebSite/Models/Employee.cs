// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;

namespace XmlFormattersWebSite.Models
{
    public class Employee
    {
        [Range(10, 100)]
        public int Id { get; set; }

        [MinLength(15)]
        public string Name { get; set; }
    }
}