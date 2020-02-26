// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.E2ETesting;
using Templates.Test.Helpers;
using Xunit;

[assembly: TestFramework("Microsoft.AspNetCore.E2ETesting.XunitTestFrameworkWithAssemblyFixture", "ProjectTemplates.Tests")]

[assembly: AssemblyFixture(typeof(ProjectFactoryFixture))]
[assembly: AssemblyFixture(typeof(SeleniumStandaloneServer))]
