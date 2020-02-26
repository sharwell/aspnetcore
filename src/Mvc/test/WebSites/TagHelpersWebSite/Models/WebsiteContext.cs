// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace TagHelpersWebSite.Models
{
    public class WebsiteContext
    {
        public Version Version { get; set; }

        public int CopyrightYear { get; set; }

        public bool Approved { get; set; }

        public int TagsToShow { get; set; }
    }
}