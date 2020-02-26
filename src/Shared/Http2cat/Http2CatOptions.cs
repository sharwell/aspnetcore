// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Http2Cat
{
    internal class Http2CatOptions
    {
        public string Url { get; set; }
        public Func<Http2Utilities, Task> Scenaro { get; set; }
    }
}
