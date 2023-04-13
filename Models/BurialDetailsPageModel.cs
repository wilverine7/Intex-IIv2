using System;
namespace Mummies.Models
{
	public class BurialDetailsPageModel
	{
		public string TextileDescription { get; set; }
		public long BurialId { get; set; }
		public string PhotoUrl { get; set; }
		public string CompKey { get; set; }
		public string Preservation { get; set; }
		public Dictionary<string, string> BurialKey {get;set;}

        public string Depth { get; set; }
        public string Facebundles { get; set; }
        public string Goods {get;set;}
        public string Text {get;set;}
        public string Wrapping { get; set; }
        public string HairColor { get; set; }
        public string SamplesCollected { get; set; }
        public string Length { get; set; }
        public string AgeatDeath { get; set; }
        public string SouthtoHead { get; set; }
        public string WesttoHead { get; set; }
        public string SouthtoFeet { get; set; }
        public string WesttoFeet { get; set; }

    }
}

