using KodalibApi.Data.Models;
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
    public DbSet<FilmsCountries> FilmsCountriesEnumerable { get; set; }
    public DbSet<FilmsGenres> FilmsGenresEnumerable { get; set; }


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
            .HasOne(fc => fc.Film)
            .WithMany(f => f.GenresList)
            .HasForeignKey(fc => fc.FilmsId);
        
        modelBuilder.Entity<FilmsGenres>()
            .HasOne(fc => fc.Genre)
            .WithMany(c => c.FilmsList)
            .HasForeignKey(fc => fc.GenreId);
    }
}