// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Core.Infrastructure
{
    /// <summary>
    /// Represents an <see cref="IActionResult"/> that is used when the
    /// antiforgery validation failed. This can be matched inside MVC result
    /// filters to process the validation failure.
    /// </summary>
    public interface IAntiforgeryValidationFailedResult : IActionResult
    { }
}