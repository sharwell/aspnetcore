// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests
{
    [CollectionDefinition(Name)]
    public class IISCompressionSiteCollection : ICollectionFixture<IISCompressionSiteFixture>
    {
        public const string Name = nameof(IISCompressionSiteCollection);
    }
}
