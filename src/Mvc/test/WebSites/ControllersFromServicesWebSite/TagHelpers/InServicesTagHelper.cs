// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ControllersFromServicesWebSite.TagHelpers
{
    [HtmlTargetElement("InServices")]
    public class InServicesTagHelper : TagHelper
    {
        private ValueService _value;

        public InServicesTagHelper(ValueService value)
        {
            _value = value;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            output.Content.SetContent(_value.Value.ToString());
        }
    }
}
