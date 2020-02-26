// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Binders
{
    /// <summary>
    /// <see cref="IModelBinder"/> implementation to bind models of type <see cref="CancellationToken"/>.
    /// </summary>
    public class CancellationTokenModelBinder : IModelBinder
    {
        /// <inheritdoc />
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // We need to force boxing now, so we can insert the same reference to the boxed CancellationToken
            // in both the ValidationState and ModelBindingResult.
            //
            // DO NOT simplify this code by removing the cast.
            var model = (object)bindingContext.HttpContext.RequestAborted;
            bindingContext.ValidationState.Add(model, new ValidationStateEntry() { SuppressValidation = true });
            bindingContext.Result = ModelBindingResult.Success(model);

            return Task.CompletedTask;
        }
    }
}
