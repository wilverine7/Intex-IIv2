using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mummies.Models.ViewModels;

namespace Mummies.Models.Infastructure
{
	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PaginationTagHelper :TagHelper
	{
		public IUrlHelperFactory uhf;

		public PaginationTagHelper(IUrlHelperFactory temp)
		{
			uhf = temp;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext vc { get; set; }

		public PageInfo PageModel { get; set; }
		public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                if (i == 1 || i == PageModel.CurrentPage || i == PageModel.TotalPages || (i >= PageModel.CurrentPage - 2 && i <= PageModel.CurrentPage + 2))
                {

                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    tb.InnerHtml.Append(i.ToString());
                }


                else if (i == PageModel.CurrentPage - 3 || i == PageModel.CurrentPage + 3)
                {
                    //display ellipsis (...) to indicate skipped pages
                    tb.InnerHtml.Append("...");
                }

                //tb.AddCssClass(PageClass);
                //tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            output.Content.AppendHtml(final.InnerHtml);

        }
    }
}



//{
      //IUrlHelper uh = uhf.GetUrlHelper(vc);

//TagBuilder final = new TagBuilder("div");

//for (int i=1; i< PageModel.TotalPages; i++)
//{
//	TagBuilder tb = new TagBuilder("a");
//	tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
//	tb.Attributes["class"] = "pageNum";
//	tb.InnerHtml.Append(i.ToString());

//	final.InnerHtml.AppendHtml(tb);
//}

//output.Content.AppendHtml(final.InnerHtml);

//         base.Process(context, output);
//     }


