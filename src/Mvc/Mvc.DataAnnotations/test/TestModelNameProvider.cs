// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Microsoft.AspNetCore.Mvc.DataAnnotations
{
    public class TestModelNameProvider : IModelNameProvider
    {
        public string Name { get; set; }
    }
}
