// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.Analyzers
{
    public class HasAttribute_ReturnsTrueForAttributesOnOverriddenMethodsAttribute : Attribute { }

    public class HasAttribute_ReturnsTrueForAttributesOnOverriddenMethodsBase
    {
        [HasAttribute_ReturnsTrueForAttributesOnOverriddenMethodsAttribute]
        public virtual void SomeMethod() { }
    }

    public class HasAttribute_ReturnsTrueForAttributesOnOverriddenMethodsTest : HasAttribute_ReturnsTrueForAttributesOnOverriddenMethodsBase
    {
        public override void SomeMethod() { }
    }
}
