// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Api.Analyzers.TestFiles.SymbolApiResponseMetadataProviderTest
{
    [ProducesErrorResponseType(typeof(GetErrorResponseType_ReturnsTypeDefinedAtControllerModel))]
    public class GetErrorResponseType_ReturnsTypeDefinedAtControllerController
    {
        public void Action() { }
    }

    public class GetErrorResponseType_ReturnsTypeDefinedAtControllerModel { }
}
