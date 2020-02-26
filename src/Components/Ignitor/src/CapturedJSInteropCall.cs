// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Ignitor
{
    public class CapturedJSInteropCall
    {
        public CapturedJSInteropCall(int asyncHandle, string identifier, string argsJson)
        {
            AsyncHandle = asyncHandle;
            Identifier = identifier;
            ArgsJson = argsJson;
        }

        public int AsyncHandle { get; }
        public string Identifier { get; }
        public string ArgsJson { get; }
    }
}
