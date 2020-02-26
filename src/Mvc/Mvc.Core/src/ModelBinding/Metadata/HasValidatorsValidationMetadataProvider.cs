// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Validation
{
    internal class HasValidatorsValidationMetadataProvider : IValidationMetadataProvider
    {
        private readonly bool _hasOnlyMetadataBasedValidators;
        private readonly IMetadataBasedModelValidatorProvider[] _validatorProviders;

        public HasValidatorsValidationMetadataProvider(IList<IModelValidatorProvider> modelValidatorProviders)
        {
            if (modelValidatorProviders.Count > 0 && modelValidatorProviders.All(p => p is IMetadataBasedModelValidatorProvider))
            {
                _hasOnlyMetadataBasedValidators = true;
                _validatorProviders = modelValidatorProviders.Cast<IMetadataBasedModelValidatorProvider>().ToArray();
            }
        }

        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!_hasOnlyMetadataBasedValidators)
            {
                return;
            }

            for (var i = 0; i < _validatorProviders.Length; i++)
            {
                var provider = _validatorProviders[i];
                if (provider.HasValidators(context.Key.ModelType, context.ValidationMetadata.ValidatorMetadata))
                {
                    context.ValidationMetadata.HasValidators = true;
                    return;
                }
            }

            if (context.ValidationMetadata.HasValidators == null)
            {
                context.ValidationMetadata.HasValidators = false;
            }
        }
    }
}
