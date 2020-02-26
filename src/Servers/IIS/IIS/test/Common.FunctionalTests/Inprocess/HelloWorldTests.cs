// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests.InProcess
{
    [Collection(IISTestSiteCollection.Name)]
    public class HelloWorldInProcessTests: FixtureLoggedTest
    {
        private readonly IISTestSiteFixture _fixture;

        public HelloWorldInProcessTests(IISTestSiteFixture fixture) : base(fixture)
        {
            _fixture = fixture;
        }

        [ConditionalFact]
        public async Task HelloWorld_InProcess()
        {
            Assert.Equal("Hello World", await _fixture.Client.GetStringAsync("/HelloWorld"));

            Assert.Equal("/Path??", await _fixture.Client.GetStringAsync("/HelloWorld/Path%3F%3F?query"));

            Assert.Equal("?query", await _fixture.Client.GetStringAsync("/HelloWorld/Query%3F%3F?query"));
        }
    }
}
