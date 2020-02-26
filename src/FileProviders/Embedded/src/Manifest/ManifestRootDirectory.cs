// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.Extensions.FileProviders.Embedded.Manifest
{
    internal class ManifestRootDirectory : ManifestDirectory
    {
        public ManifestRootDirectory(ManifestEntry[] children)
            : base(name: null, children: children)
        {
            SetParent(ManifestSinkDirectory.Instance);
        }

        public override ManifestDirectory ToRootDirectory() => this;
    }
}
