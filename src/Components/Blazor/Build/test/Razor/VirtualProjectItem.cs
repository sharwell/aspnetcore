// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;

namespace Microsoft.AspNetCore.Razor.Language
{
    internal class VirtualProjectItem : RazorProjectItem
    {
        private readonly byte[] _content;

        public VirtualProjectItem(
            string basePath,
            string filePath,
            string physicalPath,
            string relativePhysicalPath,
            string fileKind,
            byte[] content)
        {
            BasePath = basePath;
            FilePath = filePath;
            PhysicalPath = physicalPath;
            RelativePhysicalPath = relativePhysicalPath;
            _content = content;

            // Base class will detect based on file-extension.
            FileKind = fileKind ?? base.FileKind;
        }

        public override string BasePath { get; }

        public override string RelativePhysicalPath { get; }

        public override string FileKind { get; }  

        public override string FilePath { get; }

        public override string PhysicalPath { get; }

        public override bool Exists => true;

        public override Stream Read()
        {
            return new MemoryStream(_content);
        }
    }
}
