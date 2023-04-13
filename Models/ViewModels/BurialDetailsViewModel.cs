using System;
using System.Collections.Generic;

namespace Mummies.Models.ViewModels
{
	public class BurialDetailsViewModel
	{
        //this is the list of Id's 
        public List<BurialDetailsPageModel> Burialmains { get; set; }




        public List<BurialDetailsPageModel> Details { get; set; }

        public List<BurialDetailsPageModel> PhotoData { get; set; }

        public List<BurialDetailsPageModel> CompositeId { get; set; }



    }
}

