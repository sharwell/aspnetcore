// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft.AspNetCore.Blazor.Server.AutoRebuild
{
    internal static class ProcessUtils
    {
        // Based on https://stackoverflow.com/a/3346055

        public static Process GetParent(Process process)
        {
            var result = new ProcessBasicInformation();
            var handle = process.Handle;
            var status = NtQueryInformationProcess(handle, 0, ref result, Marshal.SizeOf(result), out var returnLength);
            if (status != 0)
            {
                throw new Win32Exception(status);
            }

            try
            {
                var parentProcessId = result.InheritedFromUniqueProcessId.ToInt32();
                return parentProcessId > 0 ? Process.GetProcessById(parentProcessId) : null;
            }
            catch (ArgumentException)
            {
                return null; // Process not found
            }
        }

        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, ref ProcessBasicInformation processInformation, int processInformationLength, out int returnLength);

        [StructLayout(LayoutKind.Sequential)]
        struct ProcessBasicInformation
        {
            // These members must match PROCESS_BASIC_INFORMATION
            public IntPtr Reserved1;
            public IntPtr PebBaseAddress;
            public IntPtr Reserved2_0;
            public IntPtr Reserved2_1;
            public IntPtr UniqueProcessId;
            public IntPtr InheritedFromUniqueProcessId;
        }
    }
}
