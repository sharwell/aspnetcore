// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace HtmlGenerationWebSite.Models
{
    public class AClass
    {
        public DayOfWeek DayOfWeek { get; set; }
        [DisplayFormat(DataFormatString = "Month: {0}")]
        public Month Month { get; set; }
    }
}
