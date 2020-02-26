// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Analyzers.TopLevelParameterNameAnalyzerTestFiles
{
    public class IsProblematicParameter_ReturnsTrue_IfParameterNameIsTheSameAsModelProperty
    {
        public string Model { get; set; }

        public void ActionMethod(IsProblematicParameter_ReturnsTrue_IfParameterNameIsTheSameAsModelProperty model) { }
    }
}
