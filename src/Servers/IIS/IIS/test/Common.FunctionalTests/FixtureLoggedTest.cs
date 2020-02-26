// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;
using Microsoft.AspNetCore.Testing;
using Microsoft.Extensions.Logging.Testing;
using Xunit.Abstractions;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests
{
    public class FixtureLoggedTest: LoggedTest
    {
        private readonly IISTestSiteFixture _fixture;

        public FixtureLoggedTest(IISTestSiteFixture fixture)
        {
            _fixture = fixture;
        }

        public override void Initialize(TestContext context, MethodInfo methodInfo, object[] testMethodArguments, ITestOutputHelper testOutputHelper)
        {
            base.Initialize(context, methodInfo, testMethodArguments, testOutputHelper);
            _fixture.Attach(this);
        }

        public override void Dispose()
        {
            _fixture.Detach(this);
            base.Dispose();
        }
    }
}
