// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text;

namespace Microsoft.Extensions.StackTrace.Sources
{
    internal class ParameterDisplayInfo
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Prefix { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrEmpty(Prefix))
            {
                builder
                    .Append(Prefix)
                    .Append(" ");
            }

            builder.Append(Type);
            builder.Append(" ");
            builder.Append(Name);

            return builder.ToString();
        }
    }
}
