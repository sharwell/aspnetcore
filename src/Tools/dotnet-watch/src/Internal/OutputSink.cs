// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.DotNet.Watcher.Internal
{
    public class OutputSink
    {
        public OutputCapture Current { get; private set; }
        public OutputCapture StartCapture()
        {
            return (Current = new OutputCapture());
        }
    }
}