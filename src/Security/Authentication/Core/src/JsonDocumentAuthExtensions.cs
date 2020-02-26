// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json;

namespace Microsoft.AspNetCore.Authentication
{
    public static class JsonDocumentAuthExtensions
    {
        public static string GetString(this JsonElement element, string key)
        {
            if (element.TryGetProperty(key, out var property) && property.ValueKind != JsonValueKind.Null)
            {
                return property.ToString();
            }

            return null;
        }
    }
}
