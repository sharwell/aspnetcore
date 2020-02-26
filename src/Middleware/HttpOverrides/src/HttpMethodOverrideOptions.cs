// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Builder
{
    public class HttpMethodOverrideOptions
    {
        /// <summary>
        /// Denotes the form element that contains the name of the resulting method type.
        /// If not set the X-Http-Method-Override header will be used.
        /// </summary>
        public string FormFieldName { get; set; }
    }
}
