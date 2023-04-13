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
        public IQueryable<ColorTextile> colortextiles => _context.ColorTextiles;

        public IQueryable<Color> colors => _context.Colors;

        public IQueryable<StructureTextile> structuretextiles => _context.StructureTextiles;

        public IQueryable<Structure> structures => _context.Structures;

        public IQueryable<Textilefunction> textilefunctions => _context.Textilefunctions;

        public IQueryable<TextilefunctionTextile> textilefunctiontextiles => _context.TextilefunctionTextiles;
        public IQueryable<PhotodataTextile> photodatatextiles => _context.PhotodataTextiles;
        public IQueryable<Photodatum> photodata => _context.Photodata;







    }
}

