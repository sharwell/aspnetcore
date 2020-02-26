// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Metadata
{
    /// <summary>
    /// A composite <see cref="IMetadataDetailsProvider"/>.
    /// </summary>
    public interface ICompositeMetadataDetailsProvider : 
        IBindingMetadataProvider, 
        IDisplayMetadataProvider, 
        IValidationMetadataProvider
    {
    }
}