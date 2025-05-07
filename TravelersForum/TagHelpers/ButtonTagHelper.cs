using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Homework1.TagHelpers
{
    public class ButtonTagHelper : TagHelper
    {
        public string ButtonText { get; set; } = "CLICK";
        public string ButtonType { get; set; } = "button";
        public string Href { get; set; }
        public string Class { get; set; } = "btn btn-dark";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Href))
            {
                output.TagName = "a";
                output.Attributes.SetAttribute("href", Href);
            }
            else
            {
                output.TagName = "button";
                output.Attributes.SetAttribute("type", ButtonType);
            }
            output.Attributes.SetAttribute("class", Class);
            output.Content.SetContent(ButtonText);
        }
    }
}