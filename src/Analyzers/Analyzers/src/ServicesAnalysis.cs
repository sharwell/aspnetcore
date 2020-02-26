// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace Microsoft.AspNetCore.Analyzers
{
    internal class ServicesAnalysis
    {
        public ServicesAnalysis(IMethodSymbol configureServicesMethod, ImmutableArray<ServicesItem> services)
        {
            ConfigureServicesMethod = configureServicesMethod;
            Services = services;
        }

        public INamedTypeSymbol StartupType => ConfigureServicesMethod.ContainingType;

        public IMethodSymbol ConfigureServicesMethod { get; }

        public ImmutableArray<ServicesItem> Services { get; }
    }
}
