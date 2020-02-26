// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.StackTrace.Sources
{
    /// <summary>
    /// Contains details for individual exception messages.
    /// </summary>
    internal class ExceptionDetails
    {
        /// <summary>
        /// An individual exception
        /// </summary>
        public Exception Error { get; set; }

        /// <summary>
        /// The generated stack frames
        /// </summary>
        public IEnumerable<StackFrameSourceCodeInfo> StackFrames { get; set; }

        /// <summary>
        /// Gets or sets the summary message.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
