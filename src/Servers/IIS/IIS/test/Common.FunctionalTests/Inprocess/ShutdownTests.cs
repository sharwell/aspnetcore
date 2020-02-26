// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS.FunctionalTests.Utilities;
using Microsoft.AspNetCore.Server.IntegrationTesting.IIS;
using Microsoft.AspNetCore.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests.InProcess
{
    [Collection(PublishedSitesCollection.Name)]
    public class ShutdownTests : IISFunctionalTestBase
    {
        public ShutdownTests(PublishedSitesFixture fixture) : base(fixture)
        {
        }

        [ConditionalFact]
        public async Task ShutdownTimeoutIsApplied()
        {
            var deploymentParameters = Fixture.GetBaseDeploymentParameters(Fixture.InProcessTestSite);
            deploymentParameters.TransformArguments((a, _) => $"{a} HangOnStop");
            deploymentParameters.WebConfigActionList.Add(
                WebConfigHelpers.AddOrModifyAspNetCoreSection("shutdownTimeLimit", "1"));

            var deploymentResult = await DeployAsync(deploymentParameters);

            Assert.Equal("Hello World", await deploymentResult.HttpClient.GetStringAsync("/HelloWorld"));

            StopServer();

            EventLogHelpers.VerifyEventLogEvents(deploymentResult,
                EventLogHelpers.InProcessStarted(deploymentResult),
                EventLogHelpers.InProcessFailedToStop(deploymentResult, ""));
        }

        [ConditionalTheory]
        [InlineData("/ShutdownStopAsync")]
        [InlineData("/ShutdownStopAsyncWithCancelledToken")]
        public async Task CallStopAsyncOnRequestThread_DoesNotHangIndefinitely(string path)
        {
            // Canceled token doesn't affect shutdown, in-proc doesn't handle ungraceful shutdown
            // IIS's ShutdownTimeLimit will handle that.
            var parameters = Fixture.GetBaseDeploymentParameters();
            var deploymentResult = await DeployAsync(parameters);
            try
            {
                await deploymentResult.HttpClient.GetAsync(path);
            }
            catch (HttpRequestException ex) when (ex.InnerException is IOException)
            {
                // Server might close a connection before request completes
            }

            deploymentResult.AssertWorkerProcessStop();
        }
    }
}
