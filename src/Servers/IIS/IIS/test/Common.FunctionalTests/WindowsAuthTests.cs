// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS.FunctionalTests.Utilities;
using Microsoft.AspNetCore.Server.IntegrationTesting;
using Microsoft.AspNetCore.Server.IntegrationTesting.IIS;
using Microsoft.AspNetCore.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests
{
    [Collection(PublishedSitesCollection.Name)]
    public class WindowsAuthTests : IISFunctionalTestBase
    {
        public WindowsAuthTests(PublishedSitesFixture fixture) : base(fixture)
        {
        }

        public static TestMatrix TestVariants
            => TestMatrix.ForServers(DeployerSelector.ServerType)
                .WithTfms(Tfm.NetCoreApp50)
                .WithApplicationTypes(ApplicationType.Portable)
                .WithAllHostingModels();

        [ConditionalTheory]
        [RequiresIIS(IISCapability.WindowsAuthentication)]
        [MemberData(nameof(TestVariants))]
        public async Task WindowsAuthTest(TestVariant variant)
        {
            var deploymentParameters = Fixture.GetBaseDeploymentParameters(variant);
            deploymentParameters.SetAnonymousAuth(enabled: false);
            deploymentParameters.SetWindowsAuth();

            // The default in hosting sets windows auth to true.
            var deploymentResult = await DeployAsync(deploymentParameters);

            var client = deploymentResult.CreateClient(new HttpClientHandler { UseDefaultCredentials = true });
            var response = await client.GetAsync("/Auth");
            var responseText = await response.Content.ReadAsStringAsync();

            Assert.StartsWith("Windows:", responseText);
            Assert.Contains(Environment.UserName, responseText);
        }
    }
}
