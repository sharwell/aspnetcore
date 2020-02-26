// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.E2ETesting;
using Xunit;

[assembly: TestFramework("Microsoft.AspNetCore.E2ETesting.XunitTestFrameworkWithAssemblyFixture", "Microsoft.AspNetCore.Components.E2ETests")]
[assembly: AssemblyFixture(typeof(SeleniumStandaloneServer))]
