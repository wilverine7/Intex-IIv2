using System;
namespace Mummies.Models.ViewModels
{
	public class BurialsViewModel
	{
		public IQueryable<Burialmain> Burialmains { get; set; }
		public PageInfo PageInfo { get; set; }
		



        public List<BurialPageModel> burialInfo { get; set; }
        public Dictionary<long, List<TextileData>> TextileDict = new Dictionary<long, List<TextileData>>();

		public List<Burialmain> BurialIds { get; set; }
        public List<Photodatum> PhotoData { get; set; }





    }
}

