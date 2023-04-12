using System;
namespace Mummies.Models.ViewModels
{
	public class PageInfo
	{
		public int TotalNumBurial {get;set;}
		public int BurialsPerPage { get; set; }
		public int CurrentPage { get; set; }

		//calculates number of pages needed
		public int TotalPages => (int) Math.Ceiling((double)TotalNumBurial / BurialsPerPage);
	}
}

