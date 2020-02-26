﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Net.Http.Headers;

namespace Microsoft.AspNetCore.WebUtilities
{
    /// <summary>
    /// Various extensions for converting multipart sections
    /// </summary>
    public static class MultipartSectionConverterExtensions
    {
        /// <summary>
        /// Converts the section to a file section
        /// </summary>
        /// <param name="section">The section to convert</param>
        /// <returns>A file section</returns>
        public static FileMultipartSection AsFileSection(this MultipartSection section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            try
            {
                return new FileMultipartSection(section);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converts the section to a form section
        /// </summary>
        /// <param name="section">The section to convert</param>
        /// <returns>A form section</returns>
        public static FormMultipartSection AsFormDataSection(this MultipartSection section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            try
            {
                return new FormMultipartSection(section);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves and parses the content disposition header from a section
        /// </summary>
        /// <param name="section">The section from which to retrieve</param>
        /// <returns>A <see cref="ContentDispositionHeaderValue"/> if the header was found, null otherwise</returns>
        public static ContentDispositionHeaderValue GetContentDispositionHeader(this MultipartSection section)
        {
            ContentDispositionHeaderValue header;
            if (!ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out header))
            {
                return null;
            }

            return header;
        }
    }
}
