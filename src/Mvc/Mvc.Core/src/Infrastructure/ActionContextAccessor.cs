// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    public class ActionContextAccessor : IActionContextAccessor
    {
        internal static readonly IActionContextAccessor Null = new NullActionContextAccessor();

        private static readonly AsyncLocal<ActionContext> _storage = new AsyncLocal<ActionContext>();

        public ActionContext ActionContext
        {
            get { return _storage.Value; }
            set { _storage.Value = value; }
        }

        private class NullActionContextAccessor : IActionContextAccessor
        {
            public ActionContext ActionContext
            {
                get => null;
                set { }
            }
        }
    }
}