// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests
{
    /// <summary>
    /// This type just maps collection names to available fixtures
    /// </summary>
    [CollectionDefinition(Name)]
    public class IISTestSiteCollection : ICollectionFixture<IISTestSiteFixture>
    {
        public const string Name = nameof(IISTestSiteCollection);
    }
}
