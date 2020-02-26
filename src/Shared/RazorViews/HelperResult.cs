// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;

namespace Microsoft.Extensions.RazorViews
{
    /// <summary>
    /// Represents a deferred write operation in a <see cref="BaseView"/>.
    /// </summary>
    internal class HelperResult
    {
        /// <summary>
        /// Creates a new instance of <see cref="HelperResult"/>.
        /// </summary>
        /// <param name="action">The delegate to invoke when <see cref="WriteTo(TextWriter)"/> is called.</param>
        public HelperResult(Action<TextWriter> action)
        {
            WriteAction = action;
        }

        public Action<TextWriter> WriteAction { get; }

        /// <summary>
        /// Method invoked to produce content from the <see cref="HelperResult"/>.
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> instance to write to.</param>
        public void WriteTo(TextWriter writer)
        {
            WriteAction(writer);
        }
    }
}