// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Testing
{
    public class KestrelTestLoggerProvider : ILoggerProvider
    {
        private readonly ILogger _testLogger;

        public KestrelTestLoggerProvider(bool throwOnCriticalErrors = true)
            : this(new TestApplicationErrorLogger { ThrowOnCriticalErrors = throwOnCriticalErrors })
        {
        }

        public KestrelTestLoggerProvider(ILogger testLogger)
        {
            _testLogger = testLogger;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _testLogger;
        }

        public void Dispose()
        {
        }
    }
}
