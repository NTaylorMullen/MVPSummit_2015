using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace TagHelperDemo.TagHelpers
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImgTagHelper : TagHelper
    {
        #region Image CDN Lookup
        private static readonly IReadOnlyDictionary<string, string> ImageCdnLookup = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "/images/ASP-NET-Banners-01.png", "http://compass.xbox.com/assets/0a/2a/0a2aec85-fc66-4582-9d38-ea0cc71d3796.jpg?n=Halo-5-Guardians-Live_superhero-desktop_1920x768.jpg" },
            { "/images/Banner-02-VS.png", "http://compass.xbox.com/assets/8f/7e/8f7e3d72-1c74-4e5f-b4b9-573ec44c5925.jpg?n=Best-Games_Hero_1920x768.jpg" },
            { "/images/ASP-NET-Banners-02.png", "https://c.s-microsoft.com/en-us/CMSImages/Srfc_Pro4AndBook_1006_1920x720_EN_US.jpg?version=b3d44d5d-3339-1a50-934b-38f2a2e49fe2" },
            { "/images/Banner-01-Azure.png", "https://c.s-microsoft.com/en-us/CMSImages/Win10_GA_1002_1920x720_EN_US.jpg?version=1004ec9a-0d3f-a380-3064-982bc229d4e7" },
        };
        #endregion

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var srcAttribute = output.Attributes["src"];
            var src = srcAttribute.Value.ToString();

            if (ImageCdnLookup.TryGetValue(src, out src))
            {
                srcAttribute.Value = src;
            }
        }
    }
}
