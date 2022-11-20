using KodalibApi.Data.Models;
using KodalibApi.Data.Models.ActorsTables;
using KodalibApi.Data.Models.FilmTables;
using Microsoft.EntityFrameworkCore;

namespace KodalibApi.Data.Context;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }


    public DbSet<Film> Films { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<FilmsCountries> FilmsCountriesEnumerable { get; set; }
    public DbSet<FilmsGenres> FilmsGenresEnumerable { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<TopActor> TopActors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ModelBuilder for FilmsCountries
        modelBuilder.Entity<FilmsCountries>()
            .HasKey(t => new {t.FilmsId, t.CountryId});

        modelBuilder.Entity<FilmsCountries>()
            .HasOne(fc => fc.Film)
            .WithMany(f => f.CountriesList)
            .HasForeignKey(fc => fc.FilmsId);
        
        modelBuilder.Entity<FilmsCountries>()
            .HasOne(fc => fc.Country)
            .WithMany(c => c.FilmsList)
            .HasForeignKey(fc => fc.CountryId);
        
        
        // ModelBuilder for FilmsGenres
        modelBuilder.Entity<FilmsGenres>()
            .HasKey(t => new {t.FilmsId, t.GenreId});

        modelBuilder.Entity<FilmsGenres>()
            .HasOne(fg => fg.Film)
            .WithMany(f => f.GenresList)
            .HasForeignKey(fg => fg.FilmsId);
        
        modelBuilder.Entity<FilmsGenres>()
            .HasOne(fg => fg.Genre)
            .WithMany(g => g.FilmsList)
            .HasForeignKey(fg => fg.GenreId);
        
        // ModelBuilder for TopActors
        modelBuilder.Entity<TopActor>()
            .HasKey(t => new {t.FilmId, t.ActorId});

        modelBuilder.Entity<TopActor>()
            .HasOne(fa => fa.Film)
            .WithMany(f => f.TopActors)
            .HasForeignKey(fa => fa.FilmId);
        
        modelBuilder.Entity<TopActor>()
            .HasOne(fa => fa.Actor)
            .WithMany(a => a.TopActors)
            .HasForeignKey(fa => fa.ActorId);
        
        // ModelBuilder for Character
        modelBuilder.Entity<Character>()
            .HasKey(t => new {t.FilmId, t.ActorId});

        modelBuilder.Entity<Character>()
            .HasOne(fa => fa.Film)
            .WithMany(f => f.Characters)
            .HasForeignKey(fa => fa.FilmId);
        
        modelBuilder.Entity<Character>()
            .HasOne(fa => fa.Actor)
            .WithMany(a => a.Films)
            .HasForeignKey(fa => fa.ActorId);
    }
}