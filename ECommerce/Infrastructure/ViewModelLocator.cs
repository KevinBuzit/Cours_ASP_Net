using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class ViewModelLocator : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public ViewModelLocator(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PaginationInfo PageModel { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            result.AddCssClass("text-center");
            TagBuilder list = new TagBuilder("ul");
            list.GenerateId("menu_horizontal", "");
            list.AddCssClass("pagination");
            for (int i = 1; i <= PageModel.GetNombrePage(); i++)
            {
                TagBuilder listElement = new TagBuilder("li");
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction,
                       new { page = i });
                tag.InnerHtml.Append(i.ToString());

                listElement.InnerHtml.AppendHtml(tag);
                list.InnerHtml.AppendHtml(listElement);
            }

            result.InnerHtml.AppendHtml(list);
            // Nouvelle div qui permet d'affecter une classe à la div enfant, impossible sinon ...
            TagBuilder div = new TagBuilder("div");
            div.InnerHtml.AppendHtml(result);
            output.Content.AppendHtml(div.InnerHtml);
        }
    }
}
