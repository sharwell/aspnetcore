// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Testing;

namespace Microsoft.AspNetCore.SignalR.Tests
{
    public class VerifiableLoggedTest : LoggedTest
    {
        public VerifiableLoggedTest()
        {
            // Ensures this isn't null in case the logged test framework
            // doesn't initialize it correctly.
            LoggerFactory = NullLoggerFactory.Instance;
        }

        public virtual IDisposable StartVerifiableLog(Func<WriteContext, bool> expectedErrorsFilter = null)
        {
            return CreateScope(expectedErrorsFilter);
        }

        private VerifyNoErrorsScope CreateScope(Func<WriteContext, bool> expectedErrorsFilter = null)
        {
            return new VerifyNoErrorsScope(LoggerFactory, wrappedDisposable: null, expectedErrorsFilter);
        }
    }
}
