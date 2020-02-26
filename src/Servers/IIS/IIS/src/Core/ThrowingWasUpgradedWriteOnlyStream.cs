// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Server.IIS.Core
{
    public class ThrowingWasUpgradedWriteOnlyStream : WriteOnlyStream
    {
        public override void Write(byte[] buffer, int offset, int count)
            => throw new InvalidOperationException(CoreStrings.ResponseStreamWasUpgraded);

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => throw new InvalidOperationException(CoreStrings.ResponseStreamWasUpgraded);

        public override void Flush()
            => throw new InvalidOperationException(CoreStrings.ResponseStreamWasUpgraded);

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();
    }
}
