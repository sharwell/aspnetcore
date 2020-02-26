// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    public class EmptyModelMetadataProvider : DefaultModelMetadataProvider
    {
        public EmptyModelMetadataProvider()
            : base(
                  new DefaultCompositeMetadataDetailsProvider(new List<IMetadataDetailsProvider>()),
                  new OptionsAccessor())
        {
        }

        private class OptionsAccessor : IOptions<MvcOptions>
        {
            public MvcOptions Value { get; } = new MvcOptions();
        }
    }
}