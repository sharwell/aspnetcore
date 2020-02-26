// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Binders
{
    /// <summary>
    /// An <see cref="IModelBinderProvider"/> for models which specify an <see cref="IModelBinder"/>
    /// using <see cref="BindingInfo.BinderType"/>.
    /// </summary>
    public class BinderTypeModelBinderProvider : IModelBinderProvider
    {
        /// <inheritdoc />
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.BindingInfo.BinderType != null)
            {
                return new BinderTypeModelBinder(context.BindingInfo.BinderType);
            }

            return null;
        }
    }
}
