using System;
namespace Mummies.Models.ViewModels
{
	public class BurialsViewModel
	{
		public IQueryable<Burialmain> Burialmains { get; set; }
		public PageInfo PageInfo { get; set; }
		public IQueryable<BurialmainTextile> burialmainTextiles { get; set; }
        public IQueryable<Textile> textiles { get; set; }
        public List<BurialPageModel> burialInfo { get; set; }



    }
}

