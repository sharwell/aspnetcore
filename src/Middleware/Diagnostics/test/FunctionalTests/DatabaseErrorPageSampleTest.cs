// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Diagnostics.FunctionalTests
{
    public class DatabaseErrorPageSampleTest : IClassFixture<TestFixture<DatabaseErrorPageSample.Startup>>
    {
        public DatabaseErrorPageSampleTest(TestFixture<DatabaseErrorPageSample.Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [ConditionalFact]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        public async Task DatabaseErrorPage_ShowsError()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/");

            // Act
            var response = await Client.SendAsync(request);

            // Assert
            var body = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Contains("In Visual Studio, use the Package Manager Console to scaffold a new migration and apply it to the database:", body);
        }
    }
}
