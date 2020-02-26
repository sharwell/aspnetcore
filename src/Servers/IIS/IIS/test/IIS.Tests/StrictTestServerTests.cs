// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests
{
    public class StrictTestServerTests: LoggedTest
    {
        public override void Dispose()
        {
            base.Dispose();
            Assert.DoesNotContain(TestSink.Writes, w => w.LogLevel > LogLevel.Information);
        }

        protected static TaskCompletionSource<bool> CreateTaskCompletionSource()
        {
            return new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        }
    }
}
