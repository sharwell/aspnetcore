// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS.FunctionalTests.Utilities;
using Microsoft.AspNetCore.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests.InProcess
{
    [Collection(PublishedSitesCollection.Name)]
    public class EventLogTests : IISFunctionalTestBase
    {
        public EventLogTests(PublishedSitesFixture fixture) : base(fixture)
        {
        }

        [ConditionalFact]
        public async Task CheckStartupEventLogMessage()
        {
            var deploymentParameters = Fixture.GetBaseDeploymentParameters();
            var deploymentResult = await DeployAsync(deploymentParameters);
            await deploymentResult.AssertStarts();

            StopServer();

            EventLogHelpers.VerifyEventLogEvent(deploymentResult, EventLogHelpers.InProcessStarted(deploymentResult), Logger);
        }

        [ConditionalFact]
        public async Task CheckShutdownEventLogMessage()
        {
            var deploymentParameters = Fixture.GetBaseDeploymentParameters();
            var deploymentResult = await DeployAsync(deploymentParameters);
            await deploymentResult.AssertStarts();

            StopServer();

            EventLogHelpers.VerifyEventLogEvent(deploymentResult, "Application '.+' has shutdown.", Logger);
        }
    }
}
