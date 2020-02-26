// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Microsoft.AspNetCore.Mvc.ApplicationModels
{
    /// <summary>
    /// A context object for <see cref="IPageApplicationModelProvider"/>.
    /// </summary>
    public class PageApplicationModelProviderContext
    {
        public PageApplicationModelProviderContext(PageActionDescriptor descriptor, TypeInfo pageTypeInfo)
        {
            ActionDescriptor = descriptor;
            PageType = pageTypeInfo;
        }

        /// <summary>
        /// Gets the <see cref="PageActionDescriptor"/>.
        /// </summary>
        public PageActionDescriptor ActionDescriptor { get; }

        /// <summary>
        /// Gets the page <see cref="TypeInfo"/>.
        /// </summary>
        public TypeInfo PageType { get; }

        /// <summary>
        /// Gets or sets the <see cref="ApplicationModels.PageApplicationModel"/>.
        /// </summary>
        public PageApplicationModel PageApplicationModel { get; set; }
    }
}