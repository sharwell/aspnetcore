// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.FunctionalTests
{
    public class SystemTextJsonInputFormatterTest : JsonInputFormatterTestBase<FormatterWebSite.StartupWithJsonFormatter>
    {
        public SystemTextJsonInputFormatterTest(MvcTestFixture<FormatterWebSite.StartupWithJsonFormatter> fixture)
            : base(fixture)
        {
        }

        [Theory(Skip = "https://github.com/dotnet/corefx/issues/36025")]
        [InlineData("\"I'm a JSON string!\"")]
        [InlineData("true")]
        [InlineData("\"\"")] // Empty string
        public override Task JsonInputFormatter_ReturnsDefaultValue_ForValueTypes(string input)
        {
            return base.JsonInputFormatter_ReturnsDefaultValue_ForValueTypes(input);
        }
    }
}
