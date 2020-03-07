// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace RepoTasks
{
    public class GenerateGuid : Task
    {
        [Output]
        public string Guid { get; private set; }

        [Required]
        public string NamespaceGuid { get; set; }

        [Required]
        public ITaskItem[] Values { get; set; }

        public override bool Execute()
        {
            try
            {
                var value = string.Join(",", Values.Select(o => o.ItemSpec).ToArray()).ToLowerInvariant();

                Guid = Uuid.Create(new Guid(NamespaceGuid), value).ToString();
            }
            catch (Exception e)
            {
                Log.LogErrorFromException(e);
            }

            return !Log.HasLoggedErrors;
        }
    }
}
