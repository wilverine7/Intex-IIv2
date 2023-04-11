using System;
using Mummies.Controllers;

namespace Mummies.Models.Repo
{
	public class EFMummyRepository : IMummyRepository
	{
        private MummiesDatabaseContext _context { get; set; }

        public EFMummyRepository(MummiesDatabaseContext temp)
        {
            _context = temp;
        }

        public IQueryable<Burialmain> burialdata => _context.Burialmains;
        public IQueryable<Textile> textiles => _context.Textiles;
        public IQueryable<BurialmainTextile> burialmaintextiles => _context.BurialmainTextiles;



    }
}

