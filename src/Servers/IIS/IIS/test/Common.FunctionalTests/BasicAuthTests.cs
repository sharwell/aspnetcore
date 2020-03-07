// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS.FunctionalTests.Utilities;
using Microsoft.AspNetCore.Server.IntegrationTesting;
using Microsoft.AspNetCore.Server.IntegrationTesting.IIS;
using Microsoft.AspNetCore.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests
{
    [Collection(PublishedSitesCollection.Name)]
    public class BasicAuthTests : IISFunctionalTestBase
    {
        public BasicAuthTests(PublishedSitesFixture fixture) : base(fixture)
        {
        }

        public static TestMatrix TestVariants
            => TestMatrix.ForServers(DeployerSelector.ServerType)
                .WithTfms(Tfm.NetCoreApp50)
                .WithApplicationTypes(ApplicationType.Portable)
                .WithAllHostingModels();

        [ConditionalTheory]
        [RequiresEnvironmentVariable("ASPNETCORE_MODULE_TEST_USER")]
        [RequiresIIS(IISCapability.BasicAuthentication)]
        [MemberData(nameof(TestVariants))]
        public async Task BasicAuthTest(TestVariant variant)
        {
            var username = Environment.GetEnvironmentVariable("ASPNETCORE_MODULE_TEST_USER");
            var password = Environment.GetEnvironmentVariable("ASPNETCORE_MODULE_TEST_PASSWORD");

            var deploymentParameters = Fixture.GetBaseDeploymentParameters(variant);
            deploymentParameters.SetAnonymousAuth(enabled: false);
            deploymentParameters.SetWindowsAuth(enabled: false);
            deploymentParameters.SetBasicAuth(enabled: true);

            // The default in hosting sets windows auth to true.
            var deploymentResult = await DeployAsync(deploymentParameters);
            var request = new HttpRequestMessage(HttpMethod.Get, "/Auth");
            var byteArray = new UTF8Encoding().GetBytes(username + ":" + password);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await deploymentResult.HttpClient.SendAsync(request);

            var responseText = await response.Content.ReadAsStringAsync();

            if (variant.HostingModel == HostingModel.InProcess)
            {
                Assert.StartsWith("Windows", responseText);
                Assert.Contains(username, responseText);
            }
            else
            {
                // We expect out-of-proc not allowing basic auth
                Assert.Equal("Windows", responseText);
            }
        }
    }
}
