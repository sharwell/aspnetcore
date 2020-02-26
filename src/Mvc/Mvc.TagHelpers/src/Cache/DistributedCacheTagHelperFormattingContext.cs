// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Html;

namespace Microsoft.AspNetCore.Mvc.TagHelpers.Cache
{
    /// <summary>
    /// Represents an object containing the information to serialize with <see cref="IDistributedCacheTagHelperFormatter" />.
    /// </summary>
    public class DistributedCacheTagHelperFormattingContext
    {
        /// <summary>
        /// Gets the <see cref="HtmlString"/> instance.
        /// </summary>
        public HtmlString Html { get; set; }
    }
}
