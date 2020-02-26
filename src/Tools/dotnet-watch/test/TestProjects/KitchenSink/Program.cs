// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;

namespace KitchenSink
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            // Process ID is insufficient because PID's may be reused.
            Console.WriteLine($"Process identifier = {Process.GetCurrentProcess().Id}, {Process.GetCurrentProcess().StartTime:hh:mm:ss.FF}");
            Console.WriteLine("DOTNET_WATCH = " + Environment.GetEnvironmentVariable("DOTNET_WATCH"));
            Console.WriteLine("DOTNET_WATCH_ITERATION = " + Environment.GetEnvironmentVariable("DOTNET_WATCH_ITERATION"));
        }
    }
}
