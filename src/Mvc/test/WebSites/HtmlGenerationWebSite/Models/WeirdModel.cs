// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace HtmlGenerationWebSite.Models
{
    public class WeirdModel
    {
        public string Field = "Hello, Field World!";

        public static string StaticProperty { get; set; } = "Hello, Static World!";
    }
}