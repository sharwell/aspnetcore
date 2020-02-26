// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    internal class NullableCompatibilitySwitch<TValue> : ICompatibilitySwitch where TValue : struct
    {
        private TValue? _value;

        public NullableCompatibilitySwitch(string name)
        {
            Name = name;
        }

        public bool IsValueSet { get; private set; }

        public string Name { get; }

        public TValue? Value
        {
            get => _value;
            set
            {
                IsValueSet = true;
                _value = value;
            }
        }

        object ICompatibilitySwitch.Value
        {
            get => Value;
            set => Value = (TValue?)value;
        }
    }
}
