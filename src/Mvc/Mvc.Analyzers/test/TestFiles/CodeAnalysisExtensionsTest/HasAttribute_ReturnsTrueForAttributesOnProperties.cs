// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.Analyzers
{
    public class HasAttribute_ReturnsTrueForAttributesOnPropertiesAttribute : Attribute { }

    public class HasAttribute_ReturnsTrueForAttributesOnProperties
    {
        [HasAttribute_ReturnsTrueForAttributesOnPropertiesAttribute]
        public string SomeProperty { get; set; }
    }
}
