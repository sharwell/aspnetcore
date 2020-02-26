// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Components.Forms
{
    /// <summary>
    /// Provides information about the <see cref="EditContext.OnValidationStateChanged"/> event.
    /// </summary>
    public sealed class ValidationStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a shared empty instance of <see cref="ValidationStateChangedEventArgs"/>.
        /// </summary>
        public new static readonly ValidationStateChangedEventArgs Empty = new ValidationStateChangedEventArgs();

        /// <summary>
        /// Creates a new instance of <see cref="ValidationStateChangedEventArgs" />
        /// </summary>
        public ValidationStateChangedEventArgs()
        {
        }
    }
}
