using KodalibApi.Interfaces.FilmIntefaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Genre;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.FilmRepository;

public class FilmRepository: IFilmRepository
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
        return  _context.Films.FirstOrDefault(x => x.Title == name);
    }

    public async Task<List<Film>> Select()
    {
        return await _context.Films.ToListAsync();
    }
    public async Task<Film> GetById(int id)
    {
        return await _context.Films.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<FilmViewModels> GetByIdFullDescription(int id)
    {
        return await _context.Films.Where(n=> n.Id == id).Select(film => new FilmViewModels()
        {
            Id = film.Id,
            ImdbId = film.ImdbId,
            Title = film.Title,
            Poster = film.Poster,
            Year = film.Year,
            Duration = film.Duration,
            Plot = film.Plot,
            ImdbRating =film.ImdbRating,
            Budget = film.Budget,
            GrossWorldwide = film.GrossWorldwide,
            YoutubeTrailer = film.YoutubeTrailer,
            ThumbnailUrl = film.ThumbnailUrl,
            FilmsCountriesList = film.CountriesList.Select(n => new CountryViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            FilmsGenreList = film.GenresList.Select(n => new GenreViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            TopActorsList = film.TopActors.Select(character=> new TopActorViewModel()
            {
                Id = character.ActorId,
                Actor = character.Actor.Name,
                ActorImdbId = character.Actor.PersonImdbId
            }).ToList(),
            ActorsList = film.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Actor = character.Actor.Name,
                ActorImdbId = character.Actor.PersonImdbId
            }).ToList(),
            WritersList = film.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Writer = character.WriterPerson.Name,
                WriterImdbId = character.WriterPerson.PersonImdbId
            }).ToList(),
            DirectorList = film.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Director = character.DirectorPerson.Name,
                DirectorImdbId = character.DirectorPerson.PersonImdbId
            }).ToList(),
        }).FirstOrDefaultAsync();
    }
    
    public async Task<List<FilmViewModels>> GetAllFilms()
    {
        return await _context.Films.Select(film => new FilmViewModels()
        {
            Id = film.Id,
            ImdbId = film.ImdbId,
            Title = film.Title,
            Poster = film.Poster,
            Year = film.Year,
            Duration = film.Duration,
            Plot = film.Plot,
            ImdbRating = film.ImdbRating,
            Budget = film.Budget,
            GrossWorldwide = film.GrossWorldwide,
            YoutubeTrailer = film.YoutubeTrailer,
            ThumbnailUrl = film.ThumbnailUrl,
            FilmsCountriesList = film.CountriesList.Select(n => new CountryViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            FilmsGenreList = film.GenresList.Select(n => new GenreViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            TopActorsList = film.TopActors.Select(character=> new TopActorViewModel()
            {
                Id = character.ActorId,
                Actor = character.Actor.Name,
                ActorImdbId = character.Actor.PersonImdbId
            }).ToList(),
            ActorsList = film.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Actor = character.Actor.Name,
                ActorImdbId = character.Actor.PersonImdbId
            }).ToList(),
            WritersList = film.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Writer = character.WriterPerson.Name,
                WriterImdbId = character.WriterPerson.PersonImdbId
            }).ToList(),
            DirectorList = film.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Director = character.DirectorPerson.Name,
                DirectorImdbId = character.DirectorPerson.PersonImdbId
            }).ToList(),
            
        }).ToListAsync();
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
    }

    public async Task<FilmViewModels> GetByTitleFullDescription(string title)
    {
        return await _context.Films.Where(n=> n.Title == title).Select(film => new FilmViewModels()
        {
            Id = film.Id,
            ImdbId = film.ImdbId,
            Title = film.Title,
            Poster = film.Poster,
            Year = film.Year,
            Duration = film.Duration,
            Plot = film.Plot,
            ImdbRating =film.ImdbRating,
            Budget = film.Budget,
            GrossWorldwide = film.GrossWorldwide,
            YoutubeTrailer = film.YoutubeTrailer,
            ThumbnailUrl = film.ThumbnailUrl,
            FilmsCountriesList = film.CountriesList.Select(n => new CountryViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            FilmsGenreList = film.GenresList.Select(n => new GenreViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            TopActorsList = film.TopActors.Select(character=> new TopActorViewModel()
            {
                Id = character.ActorId,
                Actor = character.Actor.Name,
                ActorImdbId = character.Actor.PersonImdbId
            }).ToList(),
            ActorsList = film.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Actor = character.Actor.Name,
                ActorImdbId = character.Actor.PersonImdbId
            }).ToList(),
            WritersList = film.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Writer = character.WriterPerson.Name,
                WriterImdbId = character.WriterPerson.PersonImdbId
            }).ToList(),
            DirectorList = film.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Director = character.DirectorPerson.Name,
                DirectorImdbId = character.DirectorPerson.PersonImdbId
            }).ToList(),
            
        }).FirstOrDefaultAsync();
    }
}