// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure
{
    /// <summary>
    /// Creates a <see cref="CompiledPageActionDescriptor"/> from a <see cref="PageActionDescriptor"/>.
    /// </summary>
#pragma warning disable CS0618 // Type or member is obsolete
    public abstract class PageLoader : IPageLoader
#pragma warning restore CS0618 // Type or member is obsolete
    {
        /// <summary>
        /// Produces a <see cref="CompiledPageActionDescriptor"/> given a <see cref="PageActionDescriptor"/>.
        /// </summary>
        /// <param name="actionDescriptor">The <see cref="PageActionDescriptor"/>.</param>
        /// <returns>A <see cref="Task"/> that on completion returns a <see cref="CompiledPageActionDescriptor"/>.</returns>
        public abstract Task<CompiledPageActionDescriptor> LoadAsync(PageActionDescriptor actionDescriptor);

        CompiledPageActionDescriptor IPageLoader.Load(PageActionDescriptor actionDescriptor)
            => LoadAsync(actionDescriptor).GetAwaiter().GetResult();
    }
}
