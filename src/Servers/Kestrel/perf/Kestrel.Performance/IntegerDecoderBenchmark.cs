// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net.Http.HPack;
using BenchmarkDotNet.Attributes;

namespace Microsoft.AspNetCore.Server.Kestrel.Performance
{
    public class IntegerDecoderBenchmark
    {
        private const int Iterations = 50_000;

        private int _prefixLength = 5; // Arbitrary prefix length
        private byte _singleByte = 0x1e; // 30
        private byte[] _multiByte = new byte[] { 0x1f, 0xe0, 0xff, 0xff, 0xff, 0x03}; // int32.MaxValue
        private IntegerDecoder _integerDecoder = new IntegerDecoder();

        [Benchmark(Baseline = true, OperationsPerInvoke = Iterations)]
        public void DecodeSingleByteInteger()
        {
            for (var i = 0; i < Iterations; i++)
            {
                _integerDecoder.BeginTryDecode(_singleByte, _prefixLength, out _);
            }
        }

        [Benchmark(OperationsPerInvoke = Iterations)]
        public void DecodeMultiByteInteger()
        {
            for (var i = 0; i < Iterations; i++)
            {
                _integerDecoder.BeginTryDecode(_multiByte[0], _prefixLength, out _);

                for (var j = 1; j < _multiByte.Length; j++)
                {
                    _integerDecoder.TryDecode(_multiByte[j], out _);
                }
            }
        }
    }
}
