using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Models.SeriesTable;
using Microsoft.EntityFrameworkCore;

namespace KodalibApi.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<FilmsCountries> FilmsCountriesEnumerable { get; set; }
    public DbSet<FilmsGenres> FilmsGenresEnumerable { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<TopActor> TopActors { get; set; }
    public DbSet<Writers> Writers { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<RolePerson> RolePersons { get; set; }

    public DbSet<Series> Series { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Episodes> Episodes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Film
        
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

        modelBuilder.Entity<Writers>()
            .HasKey(t => new {t.FilmId, t.WriterId});

        modelBuilder.Entity<Writers>()
            .HasOne(fw => fw.Film)
            .WithMany(f => f.WritersList)
            .HasForeignKey(fw => fw.FilmId);

        modelBuilder.Entity<Writers>()
            .HasOne(fw => fw.WriterPerson)
            .WithMany(w => w.Writers)
            .HasForeignKey(fw => fw.WriterId);
        
        modelBuilder.Entity<Director>()
            .HasKey(t => new {t.FilmId, t.DirectorId});

        modelBuilder.Entity<Director>()
            .HasOne(fd => fd.Film)
            .WithMany(f => f.DirectorsList)
            .HasForeignKey(fd => fd.FilmId);

        modelBuilder.Entity<Director>()
            .HasOne(fd => fd.DirectorPerson)
            .WithMany(d => d.Directors)
            .HasForeignKey(fd => fd.DirectorId);
        
        
        //Person
        
        modelBuilder.Entity<RolePerson>()
            .HasKey(t => new {t.PersonId, t.RoleId});

        modelBuilder.Entity<RolePerson>()
            .HasOne(rp => rp.Person)
            .WithMany(p => p.Role)
            .HasForeignKey(rp => rp.PersonId);

        modelBuilder.Entity<RolePerson>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.Persons)
            .HasForeignKey(fa => fa.RoleId);

        
        // Series
        
        
        modelBuilder.Entity<Episodes>()
            .HasOne(e => e.Season)
            .WithMany(s => s.Episodes)
            .HasForeignKey(e => e.SeasonId);
        
        modelBuilder.Entity<Season>()
            .HasOne(s => s.Series)
            .WithMany(s => s.Seasons)
            .HasForeignKey(e => e.SeriesId);
        
        
        modelBuilder.Entity<SeriesCountries>()
            .HasKey(t => new {t.SeriesId, t.CountryId});

        modelBuilder.Entity<SeriesCountries>()
            .HasOne(fc => fc.Series)
            .WithMany(f => f.CountriesList)
            .HasForeignKey(fc => fc.SeriesId);

        modelBuilder.Entity<SeriesCountries>()
            .HasOne(fc => fc.Country)
            .WithMany(c => c.SeriesList)
            .HasForeignKey(fc => fc.CountryId);
        
        modelBuilder.Entity<SeriesGenres>()
            .HasKey(t => new {t.SeriesId, t.GenreId});

        modelBuilder.Entity<SeriesGenres>()
            .HasOne(fg => fg.Series)
            .WithMany(f => f.GenresList)
            .HasForeignKey(fg => fg.SeriesId);

        modelBuilder.Entity<SeriesGenres>()
            .HasOne(fg => fg.Genre)
            .WithMany(g => g.SeriesList)
            .HasForeignKey(fg => fg.GenreId);
    }
}