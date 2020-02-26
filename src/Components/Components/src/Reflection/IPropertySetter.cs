// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Components.Reflection
{
    internal interface IPropertySetter
    {
        bool Cascading { get; }

        void SetValue(object target, object value);
    }
}
