// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace Microsoft.AspNetCore.Mvc.ViewFeatures
{
    /// <summary>
    /// String content which gets encoded when written.
    /// </summary>
    [DebuggerDisplay("{DebuggerToString()}")]
    public class StringHtmlContent : IHtmlContent
    {
        private readonly string _input;

        /// <summary>
        /// Creates a new instance of <see cref="StringHtmlContent"/>
        /// </summary>
        /// <param name="input"><see cref="string"/> to be HTML encoded when <see cref="WriteTo"/> is called.</param>
        public StringHtmlContent(string input)
        {
            _input = input;
        }

        /// <inheritdoc />
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            encoder.Encode(writer, _input);
        }

        private string DebuggerToString()
        {
            using (var writer = new StringWriter())
            {
                WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}