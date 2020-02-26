// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using Microsoft.AspNetCore.Server.IIS.FunctionalTests;
using Microsoft.AspNetCore.Server.IntegrationTesting.IIS;
using Xunit.Abstractions;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests.Utilities
{
    public class LogFileTestBase : IISFunctionalTestBase
    {
        protected string _logFolderPath;

        public LogFileTestBase(PublishedSitesFixture fixture, ITestOutputHelper output = null) : base(fixture, output)
        {
            _logFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        }

        public override void Dispose()
        {
            base.Dispose();
            if (Directory.Exists(_logFolderPath))
            {
                Directory.Delete(_logFolderPath, true);
            }
        }

        public string GetLogFileContent(IISDeploymentResult deploymentResult)
        {
            return Helpers.ReadAllTextFromFile(Helpers.GetExpectedLogName(deploymentResult, _logFolderPath), Logger);
        }
    }
}
