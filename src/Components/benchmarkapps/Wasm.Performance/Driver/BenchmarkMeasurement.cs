// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Wasm.Performance.Driver
{
    internal class BenchmarkMeasurement
    {
        public DateTime Timestamp { get; internal set; }
        public string Name { get; internal set; }
        public double Value { get; internal set; }
    }
}