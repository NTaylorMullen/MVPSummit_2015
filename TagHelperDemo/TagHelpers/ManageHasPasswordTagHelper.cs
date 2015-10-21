using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace TagHelperDemo.TagHelpers
{
    [OutputElementHint("a")]
    public class ManageHasPasswordTagHelper : TagHelper
    {
        private readonly IUrlHelper _urlHelper;

        public ManageHasPasswordTagHelper(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public bool Change { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var linkContent = Change ? "Change" : "Set";
            output.Content.SetContent(linkContent);

            var actionName = Change ? "ChangePassword" : "SetPassword";
            output.Attributes["href"] = _urlHelper.Action(actionName, "Manage");

            output.PreElement.SetContent("[ ");
            output.PostElement.SetContent(" ]");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
