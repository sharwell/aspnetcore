// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Extensions.StackTrace.Sources
{
    internal class MethodDisplayInfo
    {
        public string DeclaringTypeName { get; set; }

        public string Name { get; set; }

        public string GenericArguments { get; set; }

        public string SubMethod { get; set; }

        public IEnumerable<ParameterDisplayInfo> Parameters { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrEmpty(DeclaringTypeName))
            {
                builder
                    .Append(DeclaringTypeName)
                    .Append(".");
            }

            builder.Append(Name);
            builder.Append(GenericArguments);

            builder.Append("(");
            builder.AppendJoin(", ", Parameters.Select(p => p.ToString()));
            builder.Append(")");

            if (!string.IsNullOrEmpty(SubMethod))
            {
                builder.Append("+");
                builder.Append(SubMethod);
                builder.Append("()");
            }

            return builder.ToString();
        }
    }
}
