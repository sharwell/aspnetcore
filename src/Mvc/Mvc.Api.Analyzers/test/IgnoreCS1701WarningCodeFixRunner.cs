// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using Microsoft.AspNetCore.Analyzer.Testing;
using Microsoft.CodeAnalysis;

namespace Microsoft.AspNetCore.Mvc.Api.Analyzers
{
    public class IgnoreCS1701WarningCodeFixRunner : CodeFixRunner
    {
        protected override CompilationOptions ConfigureCompilationOptions(CompilationOptions options)
        {
            options = base.ConfigureCompilationOptions(options);
            return options.WithSpecificDiagnosticOptions(new[] { "CS1701" }.ToDictionary(c => c, _ => ReportDiagnostic.Suppress));
        }
    }
}