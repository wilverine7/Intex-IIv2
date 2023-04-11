using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mummies.Models.Infastructure
{
	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PaginationTagHelper :TagHelper
	{
		public PaginationTagHelper()
		{
		}
	}
}

