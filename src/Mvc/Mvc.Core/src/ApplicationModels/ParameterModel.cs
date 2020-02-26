// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.Internal;

namespace Microsoft.AspNetCore.Mvc.ApplicationModels
{
    [DebuggerDisplay("ParameterModel: Name={ParameterName}")]
    public class ParameterModel : ParameterModelBase, ICommonModel
    {
        public ParameterModel(
            ParameterInfo parameterInfo,
            IReadOnlyList<object> attributes)
            : base(parameterInfo?.ParameterType, attributes)
        {
            ParameterInfo = parameterInfo ?? throw new ArgumentNullException(nameof(parameterInfo));
        }

        public ParameterModel(ParameterModel other)
            : base(other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            Action = other.Action;
            ParameterInfo = other.ParameterInfo;
        }

        public ActionModel Action { get; set; }

        public new IDictionary<object, object> Properties => base.Properties;

        public new IReadOnlyList<object> Attributes => base.Attributes;

        MemberInfo ICommonModel.MemberInfo => ParameterInfo.Member;

        public ParameterInfo ParameterInfo { get; }

        public string ParameterName
        {
            get => Name;
            set => Name = value;
        }

        public string DisplayName
        {
            get
            {
                var parameterTypeName = TypeNameHelper.GetTypeDisplayName(ParameterInfo.ParameterType, fullName: false);
                return $"{parameterTypeName} {ParameterName}";
            }
        }
    }
}
