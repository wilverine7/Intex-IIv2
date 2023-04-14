using System;
using Microsoft.EntityFrameworkCore;
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


        public void AddBurial(Burialmain burial)
        {
            burial.Id = (_context.Burialmains
                .Max(x => x.Id) + 1);
            _context.Burialmains.Add(burial);
            _context.SaveChanges();
        }

        public void UpdateBurial(Burialmain burial)
        {
            _context.Entry(burial).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBurial(Burialmain burial)
        {
            _context.Burialmains.Remove(burial);
            _context.SaveChanges();
        }

        public Burialmain GetBurial(long burialId)
        {
            var burial = _context.Burialmains.Find(burialId);

            return burial;
        }

    }
}

