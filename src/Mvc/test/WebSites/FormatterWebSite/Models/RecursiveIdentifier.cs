// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FormatterWebSite
{
    // A System.Security.Principal.SecurityIdentifier like type that works on xplat
    public class RecursiveIdentifier : IValidatableObject
    {
        public RecursiveIdentifier(string identifier)
        {
            Value = identifier;
        }

        public string Value { get; }

        public RecursiveIdentifier AccountIdentifier => new RecursiveIdentifier(Value);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}