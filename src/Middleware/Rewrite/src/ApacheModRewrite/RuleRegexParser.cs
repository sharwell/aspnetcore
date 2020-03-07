﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Rewrite.ApacheModRewrite
{
    internal class RuleRegexParser
    {
        public ParsedModRewriteInput ParseRuleRegex(string regex)
        {
            if (string.IsNullOrEmpty(regex))
            {
                throw new FormatException("Regex expression is null");
            }
            if (regex[0] == '!')
            {
                return new ParsedModRewriteInput { Invert = true, Operand = regex.Substring(1) };
            }
            else
            {
                return new ParsedModRewriteInput { Invert = false, Operand = regex };
            }
        }
    }
}
