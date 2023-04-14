using System;
namespace Mummies.Models.Repo
{
	public interface IMummyRepository
	{
		IQueryable<Burialmain> burialdata { get; }
        IQueryable<Textile> textiles { get; }
        IQueryable<BurialmainTextile> burialmaintextiles { get; }
        IQueryable<ColorTextile> colortextiles { get; }

        IQueryable<Color> colors { get; }

        IQueryable<StructureTextile> structuretextiles { get; }

        IQueryable<Structure> structures { get; }

        IQueryable<Textilefunction> textilefunctions { get; }

        IQueryable<TextilefunctionTextile> textilefunctiontextiles { get; }
        IQueryable<PhotodataTextile> photodatatextiles { get; }
        IQueryable<Photodatum> photodata { get; }





        void AddBurial(Burialmain burial);
        void UpdateBurial(Burialmain burial);
        void DeleteBurial(Burialmain burial);
        Burialmain GetBurial(long burialId);

    }
}

