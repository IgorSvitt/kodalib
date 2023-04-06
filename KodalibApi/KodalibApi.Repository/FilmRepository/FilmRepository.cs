using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Dal.Context;
using KodalibApi.Data.Filters;
using KodalibApi.Interfaces.FilmIntefaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Models.PeopleTables.FilmPeople;
using KodalibApi.Data.Models.VoiceoverTable;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.CreateViewModels;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Genre;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.FilmRepository;

public class FilmRepository : IFilmRepository
{
    private readonly ApplicationDbContext _context;

    public FilmRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(Film entity)
    {
        _context.Films.Add(entity);
        Save();
    }

    public Film GetByName(string name)
    {
        return _context.Films.FirstOrDefault(x => x.Title == name);
    }

    public async Task<PagedList<FilmViewModels>> GetFilms(PageParameters pageParameters, FilmsFilters filmsFilters,
        CancellationToken cancellationToken)
    {
        return await PagedList<FilmViewModels>.ToPagedList(_context.Films
            .Where(filmsFilters.Country == null
                ? f => true
                : f =>
                    f.CountriesList.Any(c => filmsFilters.Country.ToLower().Contains(c.Country.Name.ToLower())))
            .Where(filmsFilters.Genre == null
                ? f => true
                : f =>
                    f.GenresList.Any(c => filmsFilters.Genre.ToLower().Contains(c.Genre.Name.ToLower())))
            .Where(filmsFilters.Year == null
                ? f => true
                : f => f.Year == filmsFilters.Year)
            .Where(filmsFilters.Title == null
            ? f => true
            : f => f.Title.ToLower().Contains(filmsFilters.Title.ToLower()))
            .Select(f => new FilmViewModels()
            {
                Id = f.Id,
                KinopoiskId = f.KinopoiskId,
                Title = f.Title,
                Plot = f.Plot,
                Poster = f.Poster,
                Year = f.Year,
                Duration = f.Duration,
                KinopoiskRating = f.KinopoiskRating,
                KodalibRating = f.KodalibRating,
                YoutubeTrailer = f.YoutubeTrailer,
                Countries = f.CountriesList.Select(c => new CountryViewModel()
                    {
                        Id = c.CountryId,
                        Name = c.Country.Name
                    })
                    .ToList(),
                Genres = f.GenresList.Select(g => new GenreViewModel()
                {
                    Id = g.GenreId,
                    Name = g.Genre.Name
                }).ToList(),
                Actors = f.Characters.Select(a => new CharacterViewModel()
                {
                    Id = a.ActorId,
                    Name = a.Actor.Name,
                }).ToList(),
                Writers = f.Writers.Select(a => new CharacterViewModel()
                {
                    Id = a.WriterId,
                    Name = a.Writer.Name,
                }).ToList(),
                Directors = f.Directors.Select(a => new CharacterViewModel()
                {
                    Id = a.DirectorId,
                    Name = a.Director.Name,
                }).ToList(),
                Voiceovers = f.Voiceovers.Select(v => new VoiceoverFilmViewModel()
                {
                    Id = v.VoiceoverId,
                    Link = v.Link,
                    Voiceover = v.Voiceover.Name
                }).ToList(),
            }).OrderByDescending(r => r.KinopoiskRating), pageParameters.PageNumber, pageParameters.PageSize, cancellationToken);
    }

    public async Task<List<FilmViewModels>> GetLastFilms(CancellationToken cancellationToken)
    {
        return await _context.Films.OrderByDescending(x => x.Id)
            .Take(10)
            .Select(film => new FilmViewModels()
            {
                Id = film.Id,
                Title = film.Title,
                Poster = film.Poster
            }).ToListAsync(cancellationToken);
    }

    public async Task<FilmViewModels?> GetFilmById(int id, CancellationToken cancellationToken)
    {
        return await _context.Films
            .Where(x => x.Id == id)
            .Select(f => new FilmViewModels()
            {
                Id = f.Id,
                KinopoiskId = f.KinopoiskId,
                Title = f.Title,
                Plot = f.Plot,
                Poster = f.Poster,
                Year = f.Year,
                Duration = f.Duration,
                KinopoiskRating = f.KinopoiskRating,
                KodalibRating = f.KodalibRating,
                YoutubeTrailer = f.YoutubeTrailer,
                Countries = f.CountriesList.Select(c => new CountryViewModel()
                    {
                        Id = c.CountryId,
                        Name = c.Country.Name
                    })
                    .ToList(),
                Genres = f.GenresList.Select(g => new GenreViewModel()
                {
                    Id = g.GenreId,
                    Name = g.Genre.Name
                }).ToList(),
                Actors = f.Characters.Select(a => new CharacterViewModel()
                {
                    Id = a.ActorId,
                    Name = a.Actor.Name,
                }).ToList(),
                Writers = f.Writers.Select(a => new CharacterViewModel()
                {
                    Id = a.WriterId,
                    Name = a.Writer.Name,
                }).ToList(),
                Directors = f.Directors.Select(a => new CharacterViewModel()
                {
                    Id = a.DirectorId,
                    Name = a.Director.Name,
                }).ToList(),
                Voiceovers = f.Voiceovers.Select(v => new VoiceoverFilmViewModel()
                {
                    Id = v.VoiceoverId,
                    Link = v.Link,
                    Voiceover = v.Voiceover.Name
                }).ToList(),
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel> CreateFilm(FilmViewModels film, CancellationToken cancellationToken)
    {
        var data = new Film()
        {
            Title = film.Title,
            Duration = film.Duration,
            KinopoiskRating = film.KinopoiskRating,
            Plot = film.Plot,
            Poster = film.Poster,
            Year = film.Year,
            KinopoiskId = film.KinopoiskId,
            YoutubeTrailer = film.YoutubeTrailer,
            CountRate = 0,
            CountriesList = film.Countries.Select(c => new FilmCountry()
            {
                CountryId = c.Id
            }).ToList(),
            GenresList = film.Genres.Select(g => new FilmGenre()
            {
                GenreId = g.Id
            }).ToList(),
            Directors = film.Directors.Select(d => new DirectorFilm()
            {
                DirectorId = d.Id
            }).ToList(),
            Writers = film.Writers.Select(w => new WriterFilm()
            {
                WriterId = w.Id
            }).ToList(),
            Characters = film.Actors.Select(a => new Character()
            {
                ActorId = a.Id
            }).ToList(),
            Voiceovers = film.Voiceovers.Select(v => new FilmVoiceover()
            {
                Link = v.Link,
                VoiceoverId = v.Id
            }).ToList(),
        };

        await _context.Films.AddAsync(data, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new IdViewModel() {Id = data.Id};
    }

    public void Delete(Film entity)
    {
        _context.Films.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Film entity)
    {
        _context.Films.Update(entity);
        Save();
    }
}