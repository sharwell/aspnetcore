// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Tools.Internal;

namespace Microsoft.DotNet.Watcher.Tools.Tests
{
    public class TestProjectGraph
    {
        private readonly TemporaryDirectory _directory;
        private Action<TemporaryCSharpProject> _onCreate;
        private readonly Dictionary<string, TemporaryCSharpProject> _projects = new Dictionary<string, TemporaryCSharpProject>();
        public TestProjectGraph(TemporaryDirectory directory)
        {
            _directory = directory;
        }

        public void OnCreate(Action<TemporaryCSharpProject> onCreate)
        {
            _onCreate = onCreate;
        }

        public TemporaryCSharpProject Find(string projectName)
            => _projects.ContainsKey(projectName)
                ? _projects[projectName]
                : null;

        public TemporaryCSharpProject GetOrCreate(string projectName)
        {
            if (!_projects.TryGetValue(projectName, out TemporaryCSharpProject sourceProj))
            {
                sourceProj = _directory.SubDir(projectName).WithCSharpProject(projectName);
                _onCreate?.Invoke(sourceProj);
                _projects.Add(projectName, sourceProj);
            }
            return sourceProj;
        }
    }
}
