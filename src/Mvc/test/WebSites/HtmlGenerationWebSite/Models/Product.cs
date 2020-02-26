// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;

namespace HtmlGenerationWebSite.Models
{
    public class Product
    {
        [Required]
        public string ProductName
        {
            get;
            set;
        }

        public int Number
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public Uri HomePage
        {
            get;
            set;
        }
    }
}