// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Buffers;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Microsoft.AspNetCore.WebUtilities.Performance
{
    /// <summary>
    /// Test internal parsing speed of FormPipeReader without pipe
    /// </summary>
    public class FormPipeReaderInternalsBenchmark
    {
        private byte[] _singleUtf8 = Encoding.UTF8.GetBytes("foo=bar&baz=boo&haha=hehe&lol=temp");
        private byte[] _firstUtf8 = Encoding.UTF8.GetBytes("foo=bar&baz=bo");
        private byte[] _secondUtf8 = Encoding.UTF8.GetBytes("o&haha=hehe&lol=temp");
        private FormPipeReader _formPipeReader;

        [IterationSetup]
        public void Setup()
        {
            _formPipeReader = new FormPipeReader(null);
        }

        [Benchmark]
        public void ReadUtf8Data()
        {
            var buffer = new ReadOnlySequence<byte>(_singleUtf8);
            KeyValueAccumulator accum = default;

            _formPipeReader.ParseFormValues(ref buffer, ref accum, isFinalBlock: true);
        }

        [Benchmark]
        public void ReadUtf8MultipleBlockData()
        {
            var buffer = ReadOnlySequenceFactory.CreateSegments(_firstUtf8, _secondUtf8);
            KeyValueAccumulator accum = default;

            _formPipeReader.ParseFormValues(ref buffer, ref accum, isFinalBlock: true);
        }
    }
}
