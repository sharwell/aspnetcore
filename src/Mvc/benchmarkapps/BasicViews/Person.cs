// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;

namespace BasicViews
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(27, MinimumLength = 2)]
        public string Name { get; set; }

        [Range(10, 54)]
        public int Age { get; set; }

        public DateTimeOffset BirthDate { get; set; }
    }
}
