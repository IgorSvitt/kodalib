using KodalibApi.Data.Models;
using KodalibApi.Data.Models.Comments;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Models.PeopleTables.FilmPeople;
using KodalibApi.Data.Models.PeopleTables.SeriesPeople;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.Models.VoiceoverTable;
using Microsoft.EntityFrameworkCore;

namespace KodalibApi.Dal.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Film> Films { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<FilmCountry> FilmsCountriesEnumerable { get; set; }
    public DbSet<FilmGenre> FilmsGenresEnumerable { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<WriterFilm> Writers { get; set; }
    public DbSet<DirectorFilm> Directors { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Episodes> Episodes { get; set; }
    public DbSet<SeriesCountries> SeriesCountries { get; set; }
    public DbSet<SeriesGenres> SeriesGenres { get; set; }
    public DbSet<CharacterSeries> CharacterSeries { get; set; }
    public DbSet<DirectorSeries> DirectorSeries { get; set; }
    public DbSet<WriterSeries> WriterSeries { get; set; }
    public DbSet<Voiceover> Voiceovers { get; set; }
    public DbSet<FilmVoiceover> FilmVoiceovers { get; set; }
    public DbSet<SeriesVoiceover> SeriesVoiceovers { get; set; }
    public DbSet<Comments> Comments { get; set; }
    public DbSet<FilmComment> FilmComments { get; set; }
    public DbSet<SeriesComment> SeriesComments { get; set; }
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FilmVoiceover>()
            .HasKey(t => new {t.FilmId, t.VoiceoverId});
        
        modelBuilder.Entity<FilmCountry>()
            .HasKey(t => new {t.FilmId, t.CountryId});
        
        modelBuilder.Entity<FilmGenre>()
            .HasKey(t => new {t.FilmId, t.GenreId});
        
        
        modelBuilder.Entity<SeriesCountries>()
            .HasKey(t => new {t.SeriesId, t.CountryId});
        
        modelBuilder.Entity<SeriesGenres>()
            .HasKey(t => new {t.SeriesId, t.GenreId});
        
        modelBuilder.Entity<Character>()
            .HasKey(t => new {t.FilmId, t.ActorId});
        
        modelBuilder.Entity<WriterFilm>()
            .HasKey(t => new {t.FilmId, t.WriterId});
        
        modelBuilder.Entity<DirectorFilm>()
            .HasKey(t => new {t.DirectorId, t.FilmId});
        
        modelBuilder.Entity<CharacterSeries>()
            .HasKey(t => new {t.SeriesId, t.ActorId});
        
        modelBuilder.Entity<WriterSeries>()
            .HasKey(t => new {t.SeriesId, t.WriterId});
        
        modelBuilder.Entity<DirectorSeries>()
            .HasKey(t => new {t.DirectorId, t.SeriesId});
        
        modelBuilder.Entity<FilmComment>()
            .HasKey(t => new {t.FilmId, t.CommentId});
        
        modelBuilder.Entity<SeriesComment>()
            .HasKey(t => new {t.CommentId, t.SeriesId});
    }
}