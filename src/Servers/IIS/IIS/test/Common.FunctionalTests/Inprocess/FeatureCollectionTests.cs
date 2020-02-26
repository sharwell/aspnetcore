// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests.InProcess
{
    [Collection(IISTestSiteCollection.Name)]
    public class FeatureCollectionTest
    {
        private readonly IISTestSiteFixture _fixture;

        public FeatureCollectionTest(IISTestSiteFixture fixture)
        {
            _fixture = fixture;
        }

        [ConditionalTheory]
        [InlineData("FeatureCollectionSetRequestFeatures")]
        [InlineData("FeatureCollectionSetResponseFeatures")]
        [InlineData("FeatureCollectionSetConnectionFeatures")]
        public async Task FeatureCollectionTest_SetHttpContextFeatures(string path)
        {
            Assert.Equal("Success", await _fixture.Client.GetStringAsync(path + "/path" + "?query"));
        }

        [ConditionalFact]
        [RequiresNewHandler]
        [RequiresNewShim]
        public async Task ExposesIServerAddressesFeature()
        {
            Assert.Equal(_fixture.Client.BaseAddress.ToString(), await _fixture.Client.GetStringAsync("/ServerAddresses"));
        }
    }
}
