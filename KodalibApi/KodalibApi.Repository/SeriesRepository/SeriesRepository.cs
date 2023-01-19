using KodalibApi.Data.Context;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Genre;
using KodalibApi.Data.ViewModels.Series;
using KodalibApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.SeriesRepository;

public class SeriesRepository: ISeriesRepository
{
    private readonly ApplicationDbContext _context;

    public SeriesRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(Series entity)
    {
        _context.Series.Add(entity);
        Save();
    }

    public async Task<Series> GetById(int id)
    {
        return await _context.Series.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Series GetByName(string name)
    {
        return  _context.Series.FirstOrDefault(x => x.Title == name);
    }

    public async Task<List<Series>> Select()
    {
        return await _context.Series.ToListAsync();
    }

    public void Delete(Series entity)
    {
        _context.Series.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Series entity)
    {
        _context.Series.Update(entity);
        Save();
    }

    public async Task<SeriesViewModel> GetByIdFullDescription(int id)
    {
        return await _context.Series.Where(n=> n.Id == id).Select(series => new SeriesViewModel()
        {
            Id = series.Id,
            KinopoiskId = series.KinopoiskId,
            Title = series.Title,
            Poster = series.Poster,
            Year = series.Year,
            Duration = series.Duration,
            Plot = series.Plot,
            KinopoiskRating =series.KinopoiskRating,
            YoutubeTrailer = series.YoutubeTrailer,
            ThumbnailUrl = series.ThumbnailUrl,
            SeriesCountriesList = series.CountriesList.Select(n => new CountryNameViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            SeriesGenreList = series.GenresList.Select(n => new GenreNameViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            ActorsList = series.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            WritersList = series.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Name = character.WriterPerson.Name,
                WriterKinopoiskId = character.WriterPerson.PersonKinopoiskId
            }).ToList(),
            DirectorList = series.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Name = character.DirectorPerson.Name,
                DirectorKinopoiskId = character.DirectorPerson.PersonKinopoiskId
            }).ToList(),
        }).FirstOrDefaultAsync();
    }

    public async Task<List<SeriesViewModel>> GetAllSeries()
    {
        return await _context.Series.Select(series => new SeriesViewModel()
        {
            Id = series.Id,
            KinopoiskId = series.KinopoiskId,
            Title = series.Title,
            Poster = series.Poster,
            Year = series.Year,
            Duration = series.Duration,
            Plot = series.Plot,
            KinopoiskRating = series.KinopoiskRating,
            YoutubeTrailer = series.YoutubeTrailer,
            ThumbnailUrl = series.ThumbnailUrl,
            SeriesCountriesList = series.CountriesList.Select(n => new CountryNameViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            SeriesGenreList = series.GenresList.Select(n => new GenreNameViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            ActorsList = series.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            WritersList = series.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Name = character.WriterPerson.Name,
                WriterKinopoiskId = character.WriterPerson.PersonKinopoiskId
            }).ToList(),
            DirectorList = series.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Name = character.DirectorPerson.Name,
                DirectorKinopoiskId = character.DirectorPerson.PersonKinopoiskId
            }).ToList(),
            
        }).ToListAsync();
    }

    public async Task<SeriesViewModel> GetByTitleFullDescription(string title)
    {
        return await _context.Films.Where(n=> n.Title == title).Select(series => new SeriesViewModel()
        {
            Id = series.Id,
            KinopoiskId = series.KinopoiskId,
            Title = series.Title,
            Poster = series.Poster,
            Year = series.Year,
            Duration = series.Duration,
            Plot = series.Plot,
            KinopoiskRating =series.KinopoiskRating,
            YoutubeTrailer = series.YoutubeTrailer,
            ThumbnailUrl = series.ThumbnailUrl,
            SeriesCountriesList = series.CountriesList.Select(n => new CountryNameViewModel()
            {
                Name = n.Country.Name
            }).ToList(),
            SeriesGenreList = series.GenresList.Select(n => new GenreNameViewModel()
            {
                Name = n.Genre.Name
            }).ToList(),
            ActorsList = series.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Role = character.Role,
                Name = character.Actor.Name,
                ActorKinopoiskId = character.Actor.PersonKinopoiskId
            }).ToList(),
            WritersList = series.WritersList.Select(character=> new WriterViewModel()
            {
                Id = character.WriterId,
                Name = character.WriterPerson.Name,
                WriterKinopoiskId = character.WriterPerson.PersonKinopoiskId
            }).ToList(),
            DirectorList = series.DirectorsList.Select(character=> new DirectorViewModel()
            {
                Id = character.DirectorId,
                Name = character.DirectorPerson.Name,
                DirectorKinopoiskId = character.DirectorPerson.PersonKinopoiskId
            }).ToList(),
            
        }).FirstOrDefaultAsync();
    }
}