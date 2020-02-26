// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Hosting.Fakes
{
    public class FakeOptions
    {
        public bool Configured { get; set; }
        public string Environment { get; set; }
        public string Message { get; set; }
    }
}