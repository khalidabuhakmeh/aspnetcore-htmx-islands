using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Razor.TagHelpers;

public enum IslandEvents
{
    Load,
    Revealed,
    Intersect
}

[HtmlTargetElement("island")]
public class IslandTagHelper : TagHelper
{
    [HtmlAttributeName("url"), Required]
    public string? Url { get; set; }

    [HtmlAttributeName("event")] 
    public IslandEvents Event { get; set; } = IslandEvents.Load;
    
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // Changing the tag name to "div"
        output.TagName = "div";

        var @event = Event switch
        {
            IslandEvents.Load => "load",
            IslandEvents.Revealed => "revealed",
            IslandEvents.Intersect => "intersect once",
            _ => "load"
        };

        output.Attributes.SetAttribute("hx-get", Url);
        output.Attributes.SetAttribute("hx-trigger", @event);
        output.Attributes.SetAttribute("hx-swap", "outerHTML");

        // Retrieve the inner content
        var childContent = await output.GetChildContentAsync();
        output.Content.SetHtmlContent(childContent);

        // Ensuring the tag is not self-closing
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}