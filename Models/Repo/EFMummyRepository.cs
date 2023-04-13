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



        public void AddBurial(Burialmain burial)
        {
            _context.Burialmains.Add(burial);
            _context.SaveChanges();
        }

        public void UpdateBurial(Burialmain burial)
        {
            _context.Entry(burial).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBurial(int burialId)
        {
            var burial = _context.Burialmains.Find(burialId);
            _context.Burialmains.Remove(burial);
            _context.SaveChanges();
        }

    }
}

