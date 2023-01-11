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
            KinopoiskId = film.KinopoiskId,
            Title = film.Title,
            LinkVideo = film.LinkVideo,
            Poster = film.Poster,
            Year = film.Year,
            Duration = film.Duration,
            Plot = film.Plot,
            KinopoiskRating =film.KinopoiskRating,
            YoutubeTrailer = film.YoutubeTrailer,
            ThumbnailUrl = film.ThumbnailUrl,
            FilmsCountriesList = film.CountriesList.Select(n => new CountryNameViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            FilmsGenreList = film.GenresList.Select(n => new GenreNameViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            TopActorsList = film.TopActors.Select(character=> new TopActorViewModel()
            {
                Id = character.ActorId,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            ActorsList = film.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            WritersList = film.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Name = character.WriterPerson.Name,
                WriterKinopoiskId = character.WriterPerson.PersonKinopoiskId
            }).ToList(),
            DirectorList = film.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Name = character.DirectorPerson.Name,
                DirectorKinopoiskId = character.DirectorPerson.PersonKinopoiskId
            }).ToList(),
        }).FirstOrDefaultAsync();
    }
    
    public async Task<List<FilmViewModels>> GetAllFilms()
    {
        return await _context.Films.Select(film => new FilmViewModels()
        {
            Id = film.Id,
            KinopoiskId = film.KinopoiskId,
            Title = film.Title,
            LinkVideo = film.LinkVideo,
            Poster = film.Poster,
            Year = film.Year,
            Duration = film.Duration,
            Plot = film.Plot,
            KinopoiskRating = film.KinopoiskRating,
            YoutubeTrailer = film.YoutubeTrailer,
            ThumbnailUrl = film.ThumbnailUrl,
            FilmsCountriesList = film.CountriesList.Select(n => new CountryNameViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            FilmsGenreList = film.GenresList.Select(n => new GenreNameViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            TopActorsList = film.TopActors.Select(character=> new TopActorViewModel()
            {
                Id = character.ActorId,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            ActorsList = film.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            WritersList = film.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Name = character.WriterPerson.Name,
                WriterKinopoiskId = character.WriterPerson.PersonKinopoiskId
            }).ToList(),
            DirectorList = film.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Name = character.DirectorPerson.Name,
                DirectorKinopoiskId = character.DirectorPerson.PersonKinopoiskId
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
        Save();
    }

    public async Task<FilmViewModels> GetByTitleFullDescription(string title)
    {
        return await _context.Films.Where(n=> n.Title == title).Select(film => new FilmViewModels()
        {
            Id = film.Id,
            KinopoiskId = film.KinopoiskId,
            Title = film.Title,
            LinkVideo = film.LinkVideo,
            Poster = film.Poster,
            Year = film.Year,
            Duration = film.Duration,
            Plot = film.Plot,
            KinopoiskRating =film.KinopoiskRating,
            YoutubeTrailer = film.YoutubeTrailer,
            ThumbnailUrl = film.ThumbnailUrl,
            FilmsCountriesList = film.CountriesList.Select(n => new CountryNameViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            FilmsGenreList = film.GenresList.Select(n => new GenreNameViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            TopActorsList = film.TopActors.Select(character=> new TopActorViewModel()
            {
                Id = character.ActorId,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            ActorsList = film.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            WritersList = film.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Name = character.WriterPerson.Name,
                WriterKinopoiskId = character.WriterPerson.PersonKinopoiskId
            }).ToList(),
            DirectorList = film.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Name = character.DirectorPerson.Name,
                DirectorKinopoiskId = character.DirectorPerson.PersonKinopoiskId
            }).ToList(),
            
        }).FirstOrDefaultAsync();
    }
}