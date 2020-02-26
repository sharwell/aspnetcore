// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.E2ETesting;
using Microsoft.AspNetCore.Testing;
using Templates.Test.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Templates.Test.SpaTemplateTest
{
    public class AngularTemplateTest : SpaTemplateTestBase
    {
        public AngularTemplateTest(ProjectFactoryFixture projectFactory, BrowserFixture browserFixture, ITestOutputHelper output)
            : base(projectFactory, browserFixture, output) { }

        [ConditionalFact]
        [SkipOnHelix("selenium")]
        public Task AngularTemplate_Works()
            => SpaTemplateImplAsync("angularnoauth", "angular", useLocalDb: false, usesAuth: false);

        [ConditionalFact]
        [SkipOnHelix("selenium")]
        public Task AngularTemplate_IndividualAuth_Works()
            => SpaTemplateImplAsync("angularindividual", "angular", useLocalDb: false, usesAuth: true);

        [ConditionalFact]
        [SkipOnHelix("selenium")]
        public Task AngularTemplate_IndividualAuth_Works_LocalDb()
            => SpaTemplateImplAsync("angularindividualuld", "angular", useLocalDb: true, usesAuth: true);
    }
}
