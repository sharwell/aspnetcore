// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO.Pipelines;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.SignalR.Microbenchmarks.Shared
{
    public class TestDuplexPipe : IDuplexPipe
    {
        private readonly TestPipeReader _input;

        public PipeReader Input => _input;

        public PipeWriter Output { get; }

        public TestDuplexPipe(bool writerForceAsync = false)
        {
            _input = new TestPipeReader();
            Output = new TestPipeWriter
            {
                ForceAsync = writerForceAsync
            };
        }

        public void AddReadResult(ValueTask<ReadResult> readResult)
        {
            _input.ReadResults.Add(readResult);
        }
    }
}