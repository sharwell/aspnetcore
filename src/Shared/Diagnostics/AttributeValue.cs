// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.DiagnosticsViewPage.Views
{
    internal class AttributeValue
    {
        public AttributeValue(string prefix, object value, bool literal)
        {
            Prefix = prefix;
            Value = value;
            Literal = literal;
        }

        public string Prefix { get; }

        public object Value { get; }

        public bool Literal { get; }

        public static AttributeValue FromTuple(Tuple<string, object, bool> value)
        {
            return new AttributeValue(value.Item1, value.Item2, value.Item3);
        }

        public static AttributeValue FromTuple(Tuple<string, string, bool> value)
        {
            return new AttributeValue(value.Item1, value.Item2, value.Item3);
        }

        public static implicit operator AttributeValue(Tuple<string, object, bool> value)
        {
            return FromTuple(value);
        }
    }
}