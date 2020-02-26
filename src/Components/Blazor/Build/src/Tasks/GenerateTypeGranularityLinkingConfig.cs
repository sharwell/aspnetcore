// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Xml.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.AspNetCore.Blazor.Build.Tasks
{
    public class GenerateTypeGranularityLinkingConfig : Task
    {
        [Required]
        public ITaskItem[] Assemblies { get; set; }

        [Required]
        public string OutputPath { get; set; }

        public override bool Execute()
        {
            var linkerElement = new XElement("linker",
                new XComment(" THIS IS A GENERATED FILE - DO NOT EDIT MANUALLY "));

            foreach (var assembly in Assemblies)
            {
                var assemblyElement = CreateTypeGranularityConfig(assembly);
                linkerElement.Add(assemblyElement);
            }

            using var fileStream = File.Open(OutputPath, FileMode.Create);
            new XDocument(linkerElement).Save(fileStream);

            return true;
        }

        private XElement CreateTypeGranularityConfig(ITaskItem assembly)
        {
            // We match all types in the assembly, and for each one, tell the linker to preserve all
            // its members (preserve=all) but only if there's some reference to the type (required=false)
            return new XElement("assembly",
                new XAttribute("fullname", Path.GetFileNameWithoutExtension(assembly.ItemSpec)),
                new XElement("type",
                    new XAttribute("fullname", "*"),
                    new XAttribute("preserve", "all"),
                    new XAttribute("required", "false")));
        }
    }
}
