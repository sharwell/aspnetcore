// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Antiforgery
{
    // Abstracts out the serialization process for an antiforgery token
    internal interface IAntiforgeryTokenSerializer
    {
        AntiforgeryToken Deserialize(string serializedToken);
        string Serialize(AntiforgeryToken token);
    }
}
