using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Framework.TagHelpers
{
    [HtmlTargetElement("html", Attributes = ForAttributeName)]
    public class HtmlTagHelper : TagHelper
    {
        private const string ForAttributeName = "use-lang";

        [HtmlAttributeName(ForAttributeName)]
        public bool UseLanguage { get; set; }

        
    }
}
