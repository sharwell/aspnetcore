// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Templates.Test.Helpers
{
    internal static class ErrorMessages
    {
        public static string GetFailedProcessMessage(string step, Project project, ProcessEx processResult)
        {
            return $@"Project {project.ProjectArguments} failed to {step}.
{processResult.GetFormattedOutput()}";
        }

        public static string GetFailedProcessMessageOrEmpty(string step, Project project, ProcessEx processResult)
        {
            return processResult.HasExited ? $@"Project {project.ProjectArguments} failed to {step}.
{processResult.GetFormattedOutput()}" : "";
        }
    }
}
