// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Identity.UI
{
    internal enum UIFramework
    {
        // The default framework for a given release must be 0.
        // So this needs to be updated in the future if we include more frameworks.
        Bootstrap4 = 0,
        Bootstrap3 = 1,
    }
}
