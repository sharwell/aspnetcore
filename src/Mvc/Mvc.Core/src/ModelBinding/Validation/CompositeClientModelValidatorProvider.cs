// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Validation
{
    /// <summary>
    /// Aggregate of <see cref="IClientModelValidatorProvider"/>s that delegates to its underlying providers.
    /// </summary>
    public class CompositeClientModelValidatorProvider : IClientModelValidatorProvider
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CompositeClientModelValidatorProvider"/>.
        /// </summary>
        /// <param name="providers">
        /// A collection of <see cref="IClientModelValidatorProvider"/> instances.
        /// </param>
        public CompositeClientModelValidatorProvider(IEnumerable<IClientModelValidatorProvider> providers)
        {
            if (providers == null)
            {
                throw new ArgumentNullException(nameof(providers));
            }

            ValidatorProviders = new List<IClientModelValidatorProvider>(providers);
        }

        /// <summary>
        /// Gets a list of <see cref="IClientModelValidatorProvider"/> instances.
        /// </summary>
        public IReadOnlyList<IClientModelValidatorProvider> ValidatorProviders { get; }

        /// <inheritdoc />
        public void CreateValidators(ClientValidatorProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // Perf: Avoid allocations
            for (var i = 0; i < ValidatorProviders.Count; i++)
            {
                ValidatorProviders[i].CreateValidators(context);
            }
        }
    }
}