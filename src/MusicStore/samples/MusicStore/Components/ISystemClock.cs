// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MusicStore.Components
{
    /// <summary>
    /// Abstracts the system clock to facilitate testing.
    /// </summary>
    public interface ISystemClock
    {
        /// <summary>
        /// Gets a DateTime object that is set to the current date and time on this computer,
        /// expressed as the Coordinated Universal Time(UTC)
        /// </summary>
        DateTime UtcNow { get; }
    }
}