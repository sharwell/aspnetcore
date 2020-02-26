﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure
{
    internal delegate Task PageHandlerBinderDelegate(PageContext pageContext, IDictionary<string, object> arguments);
}
