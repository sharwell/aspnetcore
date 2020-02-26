// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.HttpSys.Internal;

namespace Microsoft.AspNetCore.Server.IIS.Core.IO
{
    internal partial class AsyncIOEngine
    {
        private class AsyncWriteOperation : AsyncWriteOperationBase
        {
            private readonly AsyncIOEngine _engine;

            public AsyncWriteOperation(AsyncIOEngine engine)
            {
                _engine = engine;
            }

            protected override unsafe int WriteChunks(IntPtr requestHandler, int chunkCount, HttpApiTypes.HTTP_DATA_CHUNK* dataChunks,
                out bool completionExpected)
            {
                return NativeMethods.HttpWriteResponseBytes(requestHandler, dataChunks, chunkCount, out completionExpected);
            }

            protected override void ResetOperation()
            {
                base.ResetOperation();

                _engine.ReturnOperation(this);
            }
        }
    }
}
