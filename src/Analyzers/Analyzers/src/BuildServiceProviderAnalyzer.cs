// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Microsoft.AspNetCore.Analyzers
{
    internal class BuildServiceProviderValidator
    {
        private readonly StartupAnalysis _context;

        public BuildServiceProviderValidator(StartupAnalysis context)
        {
            _context = context;
        }

        public void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            Debug.Assert(context.Symbol.Kind == SymbolKind.NamedType);
            Debug.Assert(StartupFacts.IsStartupClass(_context.StartupSymbols, (INamedTypeSymbol)context.Symbol));

            var type = (INamedTypeSymbol)context.Symbol;

            foreach (var serviceAnalysis in _context.GetRelatedAnalyses<ServicesAnalysis>(type))
            {
                foreach (var serviceItem in serviceAnalysis.Services)
                {
                    if (serviceItem.UseMethod.Name == "BuildServiceProvider")
                    {
                        context.ReportDiagnostic(Diagnostic.Create(
                            StartupAnalyzer.Diagnostics.BuildServiceProviderShouldNotCalledInConfigureServicesMethod,
                            serviceItem.Operation.Syntax.GetLocation(),
                            serviceItem.UseMethod.Name,
                            serviceAnalysis.ConfigureServicesMethod.Name));
                    }
                }
            }
        }
    }
}
