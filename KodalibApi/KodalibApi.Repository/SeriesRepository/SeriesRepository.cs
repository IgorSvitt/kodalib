using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Dal.Context;
using KodalibApi.Data.Models.PeopleTables.SeriesPeople;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.ViewModels;
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

    public async Task<PagedList<SeriesViewModel>> GetSeries(PageParameters pageParameters, CancellationToken cancellationToken)
    {
        return await PagedList<SeriesViewModel>.ToPagedList(_context.Series.Select(series => new SeriesViewModel()
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
            Countries = series.Countries.Select(c => new CountryViewModel()
            {
                Id = c.Country.Id,
                Name = c.Country.Name
            }).ToList(),
            Genres = series.Genres.Select(g => new GenreViewModel()
            {
                Id = g.GenreId,
                Name = g.Genre.Name
            }).ToList(),
            Actors = series.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Name = character.Actor.Name,
            }).ToList(),
            Writers = series.Writers.Select(character=> new CharacterViewModel()
            {
                Id = character.WriterPerson.Id,
                Name = character.WriterPerson.Name,
            }).ToList(),
            Directors = series.Directors.Select(character=> new CharacterViewModel()
            {
                Id = character.DirectorPerson.Id,
                Name = character.DirectorPerson.Name,
            }).ToList(),
        }), pageParameters.PageNumber, pageParameters.PageSize, cancellationToken);
    }

    public async Task<SeriesViewModel> GetSeriesById(int id, CancellationToken cancellationToken)
    {
        return await _context.Series
            .Where(x => x.Id == id)
            .Select(series => new SeriesViewModel()
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
            Countries = series.Countries.Select(c => new CountryViewModel()
            {
                Id = c.Country.Id,
                Name = c.Country.Name
            }).ToList(),
            Genres = series.Genres.Select(g => new GenreViewModel()
            {
                Id = g.GenreId,
                Name = g.Genre.Name
            }).ToList(),
            Actors = series.Characters.Select(character=> new CharacterViewModel()
            {
                Id = character.Actor.Id,
                Name = character.Actor.Name,
            }).ToList(),
            Writers = series.Writers.Select(character=> new CharacterViewModel()
            {
                Id = character.WriterPerson.Id,
                Name = character.WriterPerson.Name,
            }).ToList(),
            Directors = series.Directors.Select(character=> new CharacterViewModel()
            {
                Id = character.DirectorPerson.Id,
                Name = character.DirectorPerson.Name,
            }).ToList(),
        }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel> CreateSeries(SeriesViewModel series, CancellationToken cancellationToken)
    {
        var data = new Series()
        {
            Title = series.Title,
            Duration = series.Duration,
            KinopoiskRating = series.KinopoiskRating,
            Plot = series.Plot,
            Poster = series.Poster,
            Year = series.Year,
            KinopoiskId = series.KinopoiskId,
            YoutubeTrailer = series.YoutubeTrailer,
            CountRate = 0,
            Countries = series.Countries.Select(c => new SeriesCountries()
            {
                CountryId = c.Id
            }).ToList(),
            Genres = series.Genres.Select(g => new SeriesGenres()
            {
                GenreId = g.Id
            }).ToList(),
            Directors = series.Directors.Select(d => new DirectorSeries()
            {
                DirectorId = d.Id
            }).ToList(),
            Writers = series.Writers.Select(w => new WriterSeries()
            {
                WriterId = w.Id
            }).ToList(),
            Characters = series.Actors.Select(a => new CharacterSeries()
            {
                ActorId = a.Id
            }).ToList(),
            Voiceovers = series.Voiceovers.Select(v => new SeriesVoiceover()
            {
                VoiceoverId = v.Id,
                CountSeasons = v.CountSeasons,
                CountEpisodes = v.CountSeasons,
                Seasons = v.Seasons.Select(x => new Season()
                {
                    NumberSeason = x.NumberSeason,
                    Episodes = x.Episodes.Select(e => new Episodes()
                    {
                        Image = e.Image,
                        NumberEpisode = e.NumberEpisode,
                        VideoLink = e.VideoLink
                    }).ToList()
                }).ToList()
            }).ToList(),
        };

        await _context.Series.AddAsync(data, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new IdViewModel() {Id = data.Id};
    }
}