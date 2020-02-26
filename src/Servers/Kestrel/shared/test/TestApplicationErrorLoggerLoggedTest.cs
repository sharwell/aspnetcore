// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;
using Microsoft.Extensions.Logging.Testing;
using Xunit.Abstractions;

namespace Microsoft.AspNetCore.Testing
{
    public class TestApplicationErrorLoggerLoggedTest : LoggedTest
    {
        public TestApplicationErrorLogger TestApplicationErrorLogger { get; private set; }

        public override void Initialize(TestContext context, MethodInfo methodInfo, object[] testMethodArguments, ITestOutputHelper testOutputHelper)
        {
            base.Initialize(context, methodInfo, testMethodArguments, testOutputHelper);

            TestApplicationErrorLogger = new TestApplicationErrorLogger();
            LoggerFactory.AddProvider(new KestrelTestLoggerProvider(TestApplicationErrorLogger));
        }
    }
}
