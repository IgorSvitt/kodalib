using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Dal.Context;
using KodalibApi.Data.Filters;
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

public class SeriesRepository : ISeriesRepository
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

    public async Task<PagedList<SeriesViewModel>> GetSeries(PageParameters pageParameters, FilmsFilters filmsFilters,
        CancellationToken cancellationToken)
    {
        return await PagedList<SeriesViewModel>.ToPagedList(_context.Series
            .Where(filmsFilters.Country == null
                ? f => true
                : f =>
                    f.Countries.Any(c => filmsFilters.Country.ToLower().Contains(c.Country.Name.ToLower())))
            .Where(filmsFilters.Genre == null
                ? f => true
                : f =>
                    f.Genres.Any(c => filmsFilters.Genre.ToLower().Contains(c.Genre.Name.ToLower())))
            .Where(filmsFilters.Year == null
                ? f => true
                : f => f.Year == filmsFilters.Year)
            .Where(filmsFilters.Title == null
                ? f => true
                : f => f.Title.ToLower().Contains(filmsFilters.Title.ToLower()))
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
                Actors = series.Characters.Select(character => new CharacterViewModel()
                {
                    Id = character.Actor.Id,
                    Name = character.Actor.Name,
                }).ToList(),
                Writers = series.Writers.Select(character => new CharacterViewModel()
                {
                    Id = character.Writer.Id,
                    Name = character.Writer.Name,
                }).ToList(),
                Directors = series.Directors.Select(character => new CharacterViewModel()
                {
                    Id = character.Director.Id,
                    Name = character.Director.Name,
                }).ToList(),
            }).OrderByDescending(r => r.KinopoiskRating), pageParameters.PageNumber, pageParameters.PageSize, cancellationToken);
    }

    public async Task<List<SeriesViewModel>> GetLastSeries(CancellationToken cancellationToken)
    {
        return await _context.Series.OrderByDescending(x => x.Id)
            .Take(10)
            .Select(series => new SeriesViewModel()
            {
                Id = series.Id,
                Poster = series.Poster,
                Title = series.Title
            }).ToListAsync(cancellationToken);
    }

    public async Task<SeriesViewModel?> GetSeriesById(int id, CancellationToken cancellationToken)
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
                Actors = series.Characters.Select(character => new CharacterViewModel()
                {
                    Id = character.Actor.Id,
                    Name = character.Actor.Name,
                }).ToList(),
                Writers = series.Writers.Select(character => new CharacterViewModel()
                {
                    Id = character.Writer.Id,
                    Name = character.Writer.Name,
                }).ToList(),
                Directors = series.Directors.Select(character => new CharacterViewModel()
                {
                    Id = character.Director.Id,
                    Name = character.Director.Name,
                }).ToList(),
                Voiceovers = series.Voiceovers.Select(x => new SeriesVoiceoverViewModel()
                {
                    Id = x.Id,
                    CountEpisodes = x.CountEpisodes,
                    CountSeasons = x.CountSeasons,
                    Voiceover = x.Voiceover.Name,
                    Seasons = x.Seasons.Select(season => new SeasonViewModel()
                    {
                        Id = season.Id,
                        NumberSeason = season.NumberSeason,
                        Episodes = season.Episodes.Select(episodes => new EpisodesViewModel()
                        {
                            Id = episodes.Id,
                            VideoLink = episodes.VideoLink,
                            Image = episodes.Image,
                            NumberEpisode = episodes.NumberEpisode
                        }).ToList(),
                    }).ToList(),
                }).ToList()
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<EpisodeViewModel?>> GetLastEpisodes(CancellationToken cancellationToken)
    {
        return await _context.Episodes.OrderByDescending(x => x.Id)
            .Take(8)
            .Select(x => new EpisodeViewModel()
            {
                Id = x.Id,
                Image = x.Image,
                NumberEpisode = x.NumberEpisode,
                VideoLink = x.VideoLink,
                Voiceover = x.Season.Voiceover.Voiceover.Name,
                Season = x.Season.NumberSeason,
                SeriesTitle = x.Season.Voiceover.Series.Title,
                SeasonId = x.SeasonId,
                SeriesId = x.Season.Voiceover.Series.Id,
                VoiceoverId = x.Season.VoiceoverId
            })
            .ToListAsync(cancellationToken);
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
                CountEpisodes = v.CountEpisodes,
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