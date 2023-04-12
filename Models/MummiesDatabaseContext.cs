using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mummies.Models;

public partial class MummiesDatabaseContext : DbContext
{
    public MummiesDatabaseContext()
    {
    }

    public MummiesDatabaseContext(DbContextOptions<MummiesDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Analysis> Analyses { get; set; }

    public virtual DbSet<AnalysisTextile> AnalysisTextiles { get; set; }

    public virtual DbSet<Artifactfagelgamousregister> Artifactfagelgamousregisters { get; set; }

    public virtual DbSet<ArtifactfagelgamousregisterBurialmain> ArtifactfagelgamousregisterBurialmains { get; set; }

    public virtual DbSet<Artifactkomaushimregister> Artifactkomaushimregisters { get; set; }

    public virtual DbSet<ArtifactkomaushimregisterBurialmain> ArtifactkomaushimregisterBurialmains { get; set; }

    public virtual DbSet<Biological> Biologicals { get; set; }

    public virtual DbSet<BiologicalC14> BiologicalC14s { get; set; }

    public virtual DbSet<Bodyanalysischart> Bodyanalysischarts { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Burialmain> Burialmains { get; set; }

    public virtual DbSet<BurialmainBiological> BurialmainBiologicals { get; set; }

    public virtual DbSet<BurialmainBodyanalysischart> BurialmainBodyanalysischarts { get; set; }

    public virtual DbSet<BurialmainCranium> BurialmainCrania { get; set; }

    public virtual DbSet<BurialmainTextile> BurialmainTextiles { get; set; }

    public virtual DbSet<C14> C14s { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<ColorTextile> ColorTextiles { get; set; }

    public virtual DbSet<Cranium> Crania { get; set; }

    public virtual DbSet<Decoration> Decorations { get; set; }

    public virtual DbSet<DecorationTextile> DecorationTextiles { get; set; }

    public virtual DbSet<Dimension> Dimensions { get; set; }

    public virtual DbSet<DimensionTextile> DimensionTextiles { get; set; }

    public virtual DbSet<Newsarticle> Newsarticles { get; set; }

    public virtual DbSet<PhotodataTextile> PhotodataTextiles { get; set; }

    public virtual DbSet<Photodatum> Photodata { get; set; }

    public virtual DbSet<Photoform> Photoforms { get; set; }

    public virtual DbSet<Structure> Structures { get; set; }

    public virtual DbSet<StructureTextile> StructureTextiles { get; set; }

    public virtual DbSet<Teammember> Teammembers { get; set; }

    public virtual DbSet<Textile> Textiles { get; set; }

    public virtual DbSet<Textilefunction> Textilefunctions { get; set; }

    public virtual DbSet<TextilefunctionTextile> TextilefunctionTextiles { get; set; }

    public virtual DbSet<Yarnmanipulation> Yarnmanipulations { get; set; }

    public virtual DbSet<YarnmanipulationTextile> YarnmanipulationTextiles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("MummiesDbConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$analysis_pkey");

            entity.ToTable("analysis");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Analysisid).HasColumnName("analysisid");
            entity.Property(e => e.Analysistype).HasColumnName("analysistype");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Doneby)
                .HasMaxLength(100)
                .HasColumnName("doneby");
        });

        modelBuilder.Entity<AnalysisTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainAnalysisid, e.MainTextileid }).HasName("main$analysis_textile_pkey");

            entity.ToTable("analysis_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainAnalysisid }, "idx_main$analysis_textile_main$textile_main$analysis");

            entity.Property(e => e.MainAnalysisid).HasColumnName("main$analysisid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });

        modelBuilder.Entity<Artifactfagelgamousregister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$artifactfagelgamousregister_pkey");

            entity.ToTable("artifactfagelgamousregister");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Coordinateset)
                .HasMaxLength(200)
                .HasColumnName("coordinateset");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Photographed)
                .HasMaxLength(3)
                .HasColumnName("photographed");
            entity.Property(e => e.Registernum)
                .HasMaxLength(30)
                .HasColumnName("registernum");
        });

        modelBuilder.Entity<ArtifactfagelgamousregisterBurialmain>(entity =>
        {
            entity.HasKey(e => new { e.MainArtifactfagelgamousregisterid, e.MainBurialmainid }).HasName("main$artifactfagelgamousregister_burialmain_pkey");

            entity.ToTable("artifactfagelgamousregister_burialmain");

            entity.HasIndex(e => new { e.MainBurialmainid, e.MainArtifactfagelgamousregisterid }, "idx_main$artifactfagelgamousregister_burialmain");

            entity.Property(e => e.MainArtifactfagelgamousregisterid).HasColumnName("main$artifactfagelgamousregisterid");
            entity.Property(e => e.MainBurialmainid).HasColumnName("main$burialmainid");
        });

        modelBuilder.Entity<Artifactkomaushimregister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$artifactqumoshimregistrar_pkey");

            entity.ToTable("artifactkomaushimregister");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Currentlocation)
                .HasMaxLength(200)
                .HasColumnName("currentlocation");
            entity.Property(e => e.Date)
                .HasMaxLength(200)
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Dimensions)
                .HasMaxLength(200)
                .HasColumnName("dimensions");
            entity.Property(e => e.Entrydate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entrydate");
            entity.Property(e => e.Excavatornum)
                .HasMaxLength(200)
                .HasColumnName("excavatornum");
            entity.Property(e => e.Finder)
                .HasMaxLength(200)
                .HasColumnName("finder");
            entity.Property(e => e.Material)
                .HasMaxLength(200)
                .HasColumnName("material");
            entity.Property(e => e.Number)
                .HasMaxLength(200)
                .HasColumnName("number");
            entity.Property(e => e.Photos)
                .HasMaxLength(3)
                .HasColumnName("photos");
            entity.Property(e => e.Position)
                .HasMaxLength(200)
                .HasColumnName("position");
            entity.Property(e => e.Provenance)
                .HasMaxLength(200)
                .HasColumnName("provenance");
            entity.Property(e => e.Qualityphotos)
                .HasMaxLength(3)
                .HasColumnName("qualityphotos");
            entity.Property(e => e.Rehousedto)
                .HasMaxLength(200)
                .HasColumnName("rehousedto");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .HasColumnName("remarks");
        });

        modelBuilder.Entity<ArtifactkomaushimregisterBurialmain>(entity =>
        {
            entity.HasKey(e => new { e.MainArtifactkomaushimregisterid, e.MainBurialmainid }).HasName("main$artifactqumoshimregistrar_burialmain_pkey");

            entity.ToTable("artifactkomaushimregister_burialmain");

            entity.HasIndex(e => new { e.MainBurialmainid, e.MainArtifactkomaushimregisterid }, "idx_main$artifactkomaushimregister_burialmain");

            entity.Property(e => e.MainArtifactkomaushimregisterid).HasColumnName("main$artifactkomaushimregisterid");
            entity.Property(e => e.MainBurialmainid).HasColumnName("main$burialmainid");
        });

        modelBuilder.Entity<Biological>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$biological_pkey");

            entity.ToTable("biological");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Bagnumber).HasColumnName("bagnumber");
            entity.Property(e => e.Clusternumber).HasColumnName("clusternumber");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Initials)
                .HasMaxLength(200)
                .HasColumnName("initials");
            entity.Property(e => e.Notes)
                .HasMaxLength(2000)
                .HasColumnName("notes");
            entity.Property(e => e.Previouslysampled)
                .HasMaxLength(200)
                .HasColumnName("previouslysampled");
            entity.Property(e => e.Racknumber).HasColumnName("racknumber");
        });

        modelBuilder.Entity<BiologicalC14>(entity =>
        {
            entity.HasKey(e => new { e.MainBiologicalid, e.MainC14id }).HasName("main$biological_c14_pkey");

            entity.ToTable("biological_c14");

            entity.HasIndex(e => new { e.MainC14id, e.MainBiologicalid }, "idx_main$biological_c14_main$c14_main$biological");

            entity.Property(e => e.MainBiologicalid).HasColumnName("main$biologicalid");
            entity.Property(e => e.MainC14id).HasColumnName("main$c14id");
        });

        modelBuilder.Entity<Bodyanalysischart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$bodyanalysischart_pkey");

            entity.ToTable("bodyanalysischart");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CariesPeriodontalDisease)
                .HasMaxLength(200)
                .HasColumnName("caries_periodontal_disease");
            entity.Property(e => e.Estimatestature).HasColumnName("estimatestature");
            entity.Property(e => e.Femur)
                .HasMaxLength(200)
                .HasColumnName("femur");
            entity.Property(e => e.Femurheaddiameter)
                .HasMaxLength(200)
                .HasColumnName("femurheaddiameter");
            entity.Property(e => e.Femurlength).HasColumnName("femurlength");
            entity.Property(e => e.Gonion)
                .HasMaxLength(200)
                .HasColumnName("gonion");
            entity.Property(e => e.Humerus)
                .HasMaxLength(200)
                .HasColumnName("humerus");
            entity.Property(e => e.Humerusheaddiameter)
                .HasMaxLength(200)
                .HasColumnName("humerusheaddiameter");
            entity.Property(e => e.Humeruslength).HasColumnName("humeruslength");
            entity.Property(e => e.Lambdoidsuture)
                .HasMaxLength(200)
                .HasColumnName("lambdoidsuture");
            entity.Property(e => e.MedicalIpRamus)
                .HasMaxLength(200)
                .HasColumnName("medical_ip_ramus");
            entity.Property(e => e.Notes)
                .HasMaxLength(2000)
                .HasColumnName("notes");
            entity.Property(e => e.Nuchalcrest)
                .HasMaxLength(200)
                .HasColumnName("nuchalcrest");
            entity.Property(e => e.Observations)
                .HasColumnType("character varying")
                .HasColumnName("observations");
            entity.Property(e => e.Orbitedge)
                .HasMaxLength(200)
                .HasColumnName("orbitedge");
            entity.Property(e => e.Osteophytosis)
                .HasMaxLength(200)
                .HasColumnName("osteophytosis");
            entity.Property(e => e.Parietalblossing).HasColumnName("parietalblossing");
            entity.Property(e => e.Perservationindex).HasColumnName("perservationindex");
            entity.Property(e => e.Robust).HasColumnName("robust");
            entity.Property(e => e.Sciaticnotch)
                .HasMaxLength(200)
                .HasColumnName("sciaticnotch");
            entity.Property(e => e.Sphenooccipitalsynchondrosis)
                .HasMaxLength(200)
                .HasColumnName("sphenooccipitalsynchondrosis");
            entity.Property(e => e.Squamossuture)
                .HasMaxLength(200)
                .HasColumnName("squamossuture");
            entity.Property(e => e.Subpubicangle)
                .HasMaxLength(200)
                .HasColumnName("subpubicangle");
            entity.Property(e => e.Supraorbitalridges)
                .HasMaxLength(200)
                .HasColumnName("supraorbitalridges");
            entity.Property(e => e.Toothattrition).HasColumnName("toothattrition");
            entity.Property(e => e.Tootheruptionageestimation).HasColumnName("tootheruptionageestimation");
            entity.Property(e => e.Ventralarc).HasColumnName("ventralarc");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(200)
                .HasColumnName("author");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Link)
                .HasMaxLength(300)
                .HasColumnName("link");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Burialmain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$burialmain_pkey");

            entity.ToTable("burialmain");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Adultsubadult)
                .HasMaxLength(200)
                .HasColumnName("adultsubadult");
            entity.Property(e => e.Ageatdeath)
                .HasMaxLength(200)
                .HasColumnName("ageatdeath");
            entity.Property(e => e.Area)
                .HasMaxLength(200)
                .HasColumnName("area");
            entity.Property(e => e.Burialid).HasColumnName("burialid");
            entity.Property(e => e.Burialmaterials)
                .HasMaxLength(5)
                .HasColumnName("burialmaterials");
            entity.Property(e => e.Burialnumber)
                .HasMaxLength(200)
                .HasColumnName("burialnumber");
            entity.Property(e => e.Clusternumber)
                .HasMaxLength(200)
                .HasColumnName("clusternumber");
            entity.Property(e => e.Dataexpertinitials)
                .HasMaxLength(200)
                .HasColumnName("dataexpertinitials");
            entity.Property(e => e.Dateofexcavation)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateofexcavation");
            entity.Property(e => e.Depth)
                .HasMaxLength(200)
                .HasColumnName("depth");
            entity.Property(e => e.Eastwest)
                .HasMaxLength(200)
                .HasColumnName("eastwest");
            entity.Property(e => e.Excavationrecorder)
                .HasMaxLength(100)
                .HasColumnName("excavationrecorder");
            entity.Property(e => e.Facebundles)
                .HasMaxLength(200)
                .HasColumnName("facebundles");
            entity.Property(e => e.Fieldbookexcavationyear)
                .HasMaxLength(200)
                .HasColumnName("fieldbookexcavationyear");
            entity.Property(e => e.Fieldbookpage)
                .HasMaxLength(200)
                .HasColumnName("fieldbookpage");
            entity.Property(e => e.Goods)
                .HasMaxLength(200)
                .HasColumnName("goods");
            entity.Property(e => e.Hair)
                .HasMaxLength(5)
                .HasColumnName("hair");
            entity.Property(e => e.Haircolor)
                .HasMaxLength(200)
                .HasColumnName("haircolor");
            entity.Property(e => e.Headdirection)
                .HasMaxLength(200)
                .HasColumnName("headdirection");
            entity.Property(e => e.Length)
                .HasMaxLength(200)
                .HasColumnName("length");
            entity.Property(e => e.Northsouth)
                .HasMaxLength(200)
                .HasColumnName("northsouth");
            entity.Property(e => e.Photos)
                .HasMaxLength(5)
                .HasColumnName("photos");
            entity.Property(e => e.Preservation)
                .HasMaxLength(200)
                .HasColumnName("preservation");
            entity.Property(e => e.Samplescollected)
                .HasMaxLength(200)
                .HasColumnName("samplescollected");
            entity.Property(e => e.Sex)
                .HasMaxLength(200)
                .HasColumnName("sex");
            entity.Property(e => e.Shaftnumber)
                .HasMaxLength(200)
                .HasColumnName("shaftnumber");
            entity.Property(e => e.Southtofeet)
                .HasMaxLength(200)
                .HasColumnName("southtofeet");
            entity.Property(e => e.Southtohead)
                .HasMaxLength(200)
                .HasColumnName("southtohead");
            entity.Property(e => e.Squareeastwest)
                .HasMaxLength(200)
                .HasColumnName("squareeastwest");
            entity.Property(e => e.Squarenorthsouth)
                .HasMaxLength(200)
                .HasColumnName("squarenorthsouth");
            entity.Property(e => e.Text)
                .HasMaxLength(2000)
                .HasColumnName("text");
            entity.Property(e => e.Westtofeet)
                .HasMaxLength(200)
                .HasColumnName("westtofeet");
            entity.Property(e => e.Westtohead)
                .HasMaxLength(200)
                .HasColumnName("westtohead");
            entity.Property(e => e.Wrapping)
                .HasMaxLength(200)
                .HasColumnName("wrapping");
        });

        modelBuilder.Entity<BurialmainBiological>(entity =>
        {
            entity.HasKey(e => new { e.MainBurialmainid, e.MainBiologicalid }).HasName("main$burialmain_biological_pkey");

            entity.ToTable("burialmain_biological");

            entity.HasIndex(e => new { e.MainBiologicalid, e.MainBurialmainid }, "idx_main$burialmain_biological_main$biological_main$burialmain");

            entity.Property(e => e.MainBurialmainid).HasColumnName("main$burialmainid");
            entity.Property(e => e.MainBiologicalid).HasColumnName("main$biologicalid");
        });

        modelBuilder.Entity<BurialmainBodyanalysischart>(entity =>
        {
            entity.HasKey(e => new { e.MainBurialmainid, e.MainBodyanalysischartid }).HasName("main$burialmain_bodyanalysischart_pkey");

            entity.ToTable("burialmain_bodyanalysischart");

            entity.HasIndex(e => new { e.MainBodyanalysischartid, e.MainBurialmainid }, "idx_main$burialmain_bodyanalysischart");

            entity.Property(e => e.MainBurialmainid).HasColumnName("main$burialmainid");
            entity.Property(e => e.MainBodyanalysischartid).HasColumnName("main$bodyanalysischartid");
        });

        modelBuilder.Entity<BurialmainCranium>(entity =>
        {
            entity.HasKey(e => new { e.MainBurialmainid, e.MainCraniumid }).HasName("main$burialmain_cranium_pkey");

            entity.ToTable("burialmain_cranium");

            entity.HasIndex(e => new { e.MainCraniumid, e.MainBurialmainid }, "idx_main$burialmain_cranium_main$cranium_main$burialmain");

            entity.Property(e => e.MainBurialmainid).HasColumnName("main$burialmainid");
            entity.Property(e => e.MainCraniumid).HasColumnName("main$craniumid");
        });

        modelBuilder.Entity<BurialmainTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainBurialmainid, e.MainTextileid }).HasName("main$burialmain_textile_pkey");

            entity.ToTable("burialmain_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainBurialmainid }, "idx_main$burialmain_textile_main$textile_main$burialmain");

            entity.Property(e => e.MainBurialmainid).HasColumnName("main$burialmainid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });

        modelBuilder.Entity<C14>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$c14_pkey");

            entity.ToTable("c14");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Agebp).HasColumnName("agebp");
            entity.Property(e => e.C14lab)
                .HasMaxLength(200)
                .HasColumnName("c14lab");
            entity.Property(e => e.Calendardate).HasColumnName("calendardate");
            entity.Property(e => e.Calibrateddateavg).HasColumnName("calibrateddateavg");
            entity.Property(e => e.Calibrateddatemax).HasColumnName("calibrateddatemax");
            entity.Property(e => e.Calibrateddatemin).HasColumnName("calibrateddatemin");
            entity.Property(e => e.Calibratedspan).HasColumnName("calibratedspan");
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.Foci)
                .HasMaxLength(200)
                .HasColumnName("foci");
            entity.Property(e => e.Location)
                .HasMaxLength(2000)
                .HasColumnName("location");
            entity.Property(e => e.Questions)
                .HasMaxLength(2000)
                .HasColumnName("questions");
            entity.Property(e => e.Rack).HasColumnName("rack");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Tubenumber).HasColumnName("tubenumber");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$color_pkey");

            entity.ToTable("color");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Colorid).HasColumnName("colorid");
            entity.Property(e => e.Value)
                .HasMaxLength(500)
                .HasColumnName("value");
        });

        modelBuilder.Entity<ColorTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainColorid, e.MainTextileid }).HasName("main$color_textile_pkey");

            entity.ToTable("color_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainColorid }, "idx_main$color_textile_main$textile_main$color");

            entity.Property(e => e.MainColorid).HasColumnName("main$colorid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });

        modelBuilder.Entity<Cranium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$cranium_pkey");

            entity.ToTable("cranium");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AlphaCore)
                .HasPrecision(28, 8)
                .HasColumnName("alpha_core");
            entity.Property(e => e.BasionBregmaHeight)
                .HasPrecision(28, 8)
                .HasColumnName("basion_bregma_height");
            entity.Property(e => e.BasionNasion)
                .HasPrecision(28, 8)
                .HasColumnName("basion_nasion");
            entity.Property(e => e.BasionProsthionLength)
                .HasPrecision(28, 8)
                .HasColumnName("basion_prosthion_length");
            entity.Property(e => e.BizygomaticDiameter)
                .HasPrecision(28, 8)
                .HasColumnName("bizygomatic_diameter");
            entity.Property(e => e.InterobitalBreadth)
                .HasPrecision(28, 8)
                .HasColumnName("interobital_breadth");
            entity.Property(e => e.InterorbitalBreadth)
                .HasPrecision(28, 8)
                .HasColumnName("interorbital_breadth");
            entity.Property(e => e.InterorbitalSubtense)
                .HasPrecision(28, 8)
                .HasColumnName("interorbital_subtense");
            entity.Property(e => e.MaxNasalBreadth)
                .HasPrecision(28, 8)
                .HasColumnName("max_nasal_breadth");
            entity.Property(e => e.Maxcraniumbreadth)
                .HasPrecision(28, 8)
                .HasColumnName("maxcraniumbreadth");
            entity.Property(e => e.Maxcraniumlength)
                .HasPrecision(28, 8)
                .HasColumnName("maxcraniumlength");
            entity.Property(e => e.MidOrbitalBreadth)
                .HasPrecision(28, 8)
                .HasColumnName("mid_orbital_breadth");
            entity.Property(e => e.MidOrbitalSubtense)
                .HasPrecision(28, 8)
                .HasColumnName("mid_orbital_subtense");
            entity.Property(e => e.NasionProsthionUpper)
                .HasPrecision(28, 8)
                .HasColumnName("nasion_prosthion_upper");
            entity.Property(e => e.NasoAlphaSubtense)
                .HasPrecision(28, 8)
                .HasColumnName("naso_alpha__subtense");
        });

        modelBuilder.Entity<Decoration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$decoration_pkey");

            entity.ToTable("decoration");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Decorationid).HasColumnName("decorationid");
            entity.Property(e => e.Value)
                .HasMaxLength(500)
                .HasColumnName("value");
        });

        modelBuilder.Entity<DecorationTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainDecorationid, e.MainTextileid }).HasName("main$decoration_textile_pkey");

            entity.ToTable("decoration_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainDecorationid }, "idx_main$decoration_textile_main$textile_main$decoration");

            entity.Property(e => e.MainDecorationid).HasColumnName("main$decorationid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });

        modelBuilder.Entity<Dimension>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$dimension_pkey");

            entity.ToTable("dimension");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Dimensionid).HasColumnName("dimensionid");
            entity.Property(e => e.Dimensiontype)
                .HasMaxLength(500)
                .HasColumnName("dimensiontype");
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .HasColumnName("value");
        });

        modelBuilder.Entity<DimensionTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainDimensionid, e.MainTextileid }).HasName("main$dimension_textile_pkey");

            entity.ToTable("dimension_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainDimensionid }, "idx_main$dimension_textile_main$textile_main$dimension");

            entity.Property(e => e.MainDimensionid).HasColumnName("main$dimensionid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });

        modelBuilder.Entity<Newsarticle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$newsarticle_pkey");

            entity.ToTable("newsarticle");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasColumnType("character varying")
                .HasColumnName("author");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.Urltoimage)
                .HasColumnType("character varying")
                .HasColumnName("urltoimage");
        });

        modelBuilder.Entity<PhotodataTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainPhotodataid, e.MainTextileid }).HasName("main$photodata_textile_pkey");

            entity.ToTable("photodata_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainPhotodataid }, "idx_main$photodata_textile_main$textile_main$photodata");

            entity.Property(e => e.MainPhotodataid).HasColumnName("main$photodataid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });

        modelBuilder.Entity<Photodatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$photodata_pkey");

            entity.ToTable("photodata");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Filename)
                .HasMaxLength(200)
                .HasColumnName("filename");
            entity.Property(e => e.Photodataid).HasColumnName("photodataid");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Photoform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$photoform_pkey");

            entity.ToTable("photoform");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Area)
                .HasMaxLength(100)
                .HasColumnName("area");
            entity.Property(e => e.Burialnumber)
                .HasMaxLength(10)
                .HasColumnName("burialnumber");
            entity.Property(e => e.Eastwest)
                .HasMaxLength(1)
                .HasColumnName("eastwest");
            entity.Property(e => e.Filename)
                .HasMaxLength(200)
                .HasColumnName("filename");
            entity.Property(e => e.Northsouth)
                .HasMaxLength(1)
                .HasColumnName("northsouth");
            entity.Property(e => e.Photodate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("photodate");
            entity.Property(e => e.Photographer)
                .HasMaxLength(100)
                .HasColumnName("photographer");
            entity.Property(e => e.Squareeastwest)
                .HasMaxLength(100)
                .HasColumnName("squareeastwest");
            entity.Property(e => e.Squarenorthsouth)
                .HasMaxLength(5)
                .HasColumnName("squarenorthsouth");
            entity.Property(e => e.Tableassociation)
                .HasMaxLength(10)
                .HasColumnName("tableassociation");
        });

        modelBuilder.Entity<Structure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$structure_pkey");

            entity.ToTable("structure");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Structureid).HasColumnName("structureid");
            entity.Property(e => e.Value)
                .HasMaxLength(500)
                .HasColumnName("value");
        });

        modelBuilder.Entity<StructureTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainStructureid, e.MainTextileid }).HasName("main$structure_textile_pkey");

            entity.ToTable("structure_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainStructureid }, "idx_main$structure_textile_main$textile_main$structure");

            entity.Property(e => e.MainStructureid).HasColumnName("main$structureid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });

        modelBuilder.Entity<Teammember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$teammember_pkey");

            entity.ToTable("teammember");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Bio)
                .HasColumnType("character varying")
                .HasColumnName("bio");
            entity.Property(e => e.Membername)
                .HasMaxLength(200)
                .HasColumnName("membername");
        });

        modelBuilder.Entity<Textile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$textile_pkey");

            entity.ToTable("textile");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Burialnumber)
                .HasMaxLength(200)
                .HasColumnName("burialnumber");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Direction)
                .HasMaxLength(200)
                .HasColumnName("direction");
            entity.Property(e => e.Estimatedperiod)
                .HasMaxLength(200)
                .HasColumnName("estimatedperiod");
            entity.Property(e => e.Locale)
                .HasMaxLength(200)
                .HasColumnName("locale");
            entity.Property(e => e.Photographeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("photographeddate");
            entity.Property(e => e.Sampledate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sampledate");
            entity.Property(e => e.Textileid).HasColumnName("textileid");
        });

        modelBuilder.Entity<Textilefunction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$textilefunction_pkey");

            entity.ToTable("textilefunction");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Textilefunctionid).HasColumnName("textilefunctionid");
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .HasColumnName("value");
        });

        modelBuilder.Entity<TextilefunctionTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainTextilefunctionid, e.MainTextileid }).HasName("main$textilefunction_textile_pkey");

            entity.ToTable("textilefunction_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainTextilefunctionid }, "idx_main$textilefunction_textile");

            entity.Property(e => e.MainTextilefunctionid).HasColumnName("main$textilefunctionid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });

        modelBuilder.Entity<Yarnmanipulation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("main$yarnmanipulation_pkey");

            entity.ToTable("yarnmanipulation");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Angle)
                .HasMaxLength(20)
                .HasColumnName("angle");
            entity.Property(e => e.Component)
                .HasMaxLength(200)
                .HasColumnName("component");
            entity.Property(e => e.Count)
                .HasMaxLength(100)
                .HasColumnName("count");
            entity.Property(e => e.Direction)
                .HasMaxLength(20)
                .HasColumnName("direction");
            entity.Property(e => e.Manipulation)
                .HasMaxLength(100)
                .HasColumnName("manipulation");
            entity.Property(e => e.Material)
                .HasMaxLength(100)
                .HasColumnName("material");
            entity.Property(e => e.Ply)
                .HasMaxLength(20)
                .HasColumnName("ply");
            entity.Property(e => e.Thickness)
                .HasMaxLength(20)
                .HasColumnName("thickness");
            entity.Property(e => e.Yarnmanipulationid).HasColumnName("yarnmanipulationid");
        });

        modelBuilder.Entity<YarnmanipulationTextile>(entity =>
        {
            entity.HasKey(e => new { e.MainYarnmanipulationid, e.MainTextileid }).HasName("main$yarnmanipulation_textile_pkey");

            entity.ToTable("yarnmanipulation_textile");

            entity.HasIndex(e => new { e.MainTextileid, e.MainYarnmanipulationid }, "idx_main$yarnmanipulation_textile");

            entity.Property(e => e.MainYarnmanipulationid).HasColumnName("main$yarnmanipulationid");
            entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
        });
        modelBuilder.HasSequence("excelimporter$template_nr_mxseq");
        modelBuilder.HasSequence("system$filedocument_fileid_mxseq");
        modelBuilder.HasSequence("system$queuedtask_sequence_mxseq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
