// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Identity
{
    /// <summary>
    /// Used to indicate that a something is considered personal data and should be protected.
    /// </summary>
    public class ProtectedPersonalDataAttribute : PersonalDataAttribute
    { }
}