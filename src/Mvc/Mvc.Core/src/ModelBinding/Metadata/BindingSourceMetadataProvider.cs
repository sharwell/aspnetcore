﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Metadata
{
    public class BindingSourceMetadataProvider : IBindingMetadataProvider
    {
        /// <summary>
        /// Creates a new <see cref="BindingSourceMetadataProvider"/> for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/>. The provider sets <see cref="BindingSource"/> of the given <see cref="Type"/> or 
        /// anything assignable to the given <see cref="Type"/>. 
        /// </param>
        /// <param name="bindingSource">
        /// The <see cref="BindingSource"/> to assign to the given <paramref name="type"/>.
        /// </param>
        public BindingSourceMetadataProvider(Type type, BindingSource bindingSource)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            Type = type;
            BindingSource = bindingSource;
        }

        public Type Type { get; }
        public BindingSource BindingSource { get; }

        /// <inheritdoc />
        public void CreateBindingMetadata(BindingMetadataProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (Type.IsAssignableFrom(context.Key.ModelType))
            {
                context.BindingMetadata.BindingSource = BindingSource;
            }
        }
    }
}
