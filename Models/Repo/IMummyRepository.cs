using System;
namespace Mummies.Models.Repo
{
	public interface IMummyRepository
	{
		IQueryable<Burialmain> burialdata { get; }
        IQueryable<Textile> textiles { get; }
        IQueryable<BurialmainTextile> burialmaintextiles { get; }



    }
}

