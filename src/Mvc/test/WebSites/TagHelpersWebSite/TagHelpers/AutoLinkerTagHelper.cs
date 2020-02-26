// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersWebSite.TagHelpers
{
    [HtmlTargetElement("p")]
    public class AutoLinkerTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            // Find Urls in the content and replace them with their anchor tag equivalent.
            output.Content.AppendHtml(Regex.Replace(
                childContent.GetContent(),
                @"\b(?:https?://|www\.)(\S+)\b",
                "<strong><a target=\"_blank\" href=\"http://$0\">$0</a></strong>"));
        }
    }
}