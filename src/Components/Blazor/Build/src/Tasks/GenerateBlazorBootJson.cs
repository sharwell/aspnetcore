// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.AspNetCore.Blazor.Build
{
    public class GenerateBlazorBootJson : Task
    {
        [Required]
        public string AssemblyPath { get; set; }

        [Required]
        public ITaskItem[] References { get; set; }

        [Required]
        public bool LinkerEnabled { get; set; }

        [Required]
        public string OutputPath { get; set; }

        public override bool Execute()
        {
            var entryAssemblyName = AssemblyName.GetAssemblyName(AssemblyPath).Name;
            var assemblies = References.Select(GetUriPath).OrderBy(c => c, StringComparer.Ordinal).ToArray();

            using var fileStream = File.Create(OutputPath);
            WriteBootJson(fileStream, entryAssemblyName, assemblies, LinkerEnabled);

            return true;

            static string GetUriPath(ITaskItem item)
            {
                var outputPath = item.GetMetadata("RelativeOutputPath");
                if (string.IsNullOrEmpty(outputPath))
                {
                    outputPath = Path.GetFileName(item.ItemSpec);
                }

                return outputPath.Replace('\\', '/');
            }
        }

        internal static void WriteBootJson(Stream stream, string entryAssemblyName, string[] assemblies, bool linkerEnabled)
        {
            var data = new BootJsonData
            {
                entryAssembly = entryAssemblyName,
                assemblies = assemblies,
                linkerEnabled = linkerEnabled,
            };

            var serializer = new DataContractJsonSerializer(typeof(BootJsonData));
            serializer.WriteObject(stream, data);
        }

        /// <summary>
        /// Defines the structure of a Blazor boot JSON file
        /// </summary>
#pragma warning disable IDE1006 // Naming Styles
        public class BootJsonData
        {
            /// <summary>
            /// Gets the name of the assembly with the application entry point
            /// </summary>
            public string entryAssembly { get; set; }

            /// <summary>
            /// Gets the closure of assemblies to be loaded by Blazor WASM. This includes the application entry assembly.
            /// </summary>
            public string[] assemblies { get; set; }

            /// <summary>
            /// Gets a value that determines if the linker is enabled.
            /// </summary>
            public bool linkerEnabled { get; set; }
        }
#pragma warning restore IDE1006 // Naming Styles
    }
}
