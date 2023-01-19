using Kodalib.Service.Interfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Models.PeopleTables.SeriesPeople;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Series;
using KodalibApi.Interfaces;
using KodalibApi.Interfaces.CountryInterfaces;
using KodalibApi.Interfaces.FilmIntefaces;
using KodalibApi.Interfaces.GenreInterfaces;
using KodalibApi.Interfaces.PeopleInterface;

namespace Kodalib.Service.Implementations;

public class SeriesService : ISeriesService
{
    private readonly ISeriesRepository _seriesRepository;
    private readonly ApplicationDbContext _context;
    private readonly ICountryRepository _countryRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPersonRepository _actorRepository;


    public SeriesService(ISeriesRepository seriesRepository, ApplicationDbContext context,
        ICountryRepository countryRepository,
        IGenreRepository genreRepository, IPersonRepository actorRepository)
    {
        _seriesRepository = seriesRepository;
        _context = context;
        _countryRepository = countryRepository;
        _genreRepository = genreRepository;
        _actorRepository = actorRepository;
    }

    public IBaseResponce<IEnumerable<SeriesViewModel>> GetSeries()
    {
        var baseResponse = new BaseResponce<IEnumerable<SeriesViewModel>>();

        try
        {
            var series = _seriesRepository.GetAllSeries();
            if (series.Result.Count == 0)
            {
                baseResponse.Description = "Found 0 elements";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = series.Result;
            baseResponse.StatusCode = StatusCode.OK;


            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponce<IEnumerable<SeriesViewModel>>()
            {
                Description = $"[GetFilms] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<SeriesViewModel> GetOneSeries(int id)
    {
        var baseResponse = new BaseResponce<SeriesViewModel>();

        try
        {
            var series = _seriesRepository.GetByIdFullDescription(id);
            if (series.Result == null)
            {
                baseResponse.Description = "Found 0 elements";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = series.Result;
            baseResponse.StatusCode = StatusCode.OK;


            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponce<SeriesViewModel>()
            {
                Description = $"[GetFilms] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<Series> GetSeriesByName(string name)
    {
        throw new NotImplementedException();
    }

    public IBaseResponce<bool> DeleteSeries(int id)
    {
        var baseResponse = new BaseResponce<bool>();

        try
        {
            var series = _seriesRepository.GetById(id);
            if (series == null)
            {
                baseResponse.Description = "Series not found";
                baseResponse.StatusCode = StatusCode.SeriesNotFound;
                baseResponse.Data = false;
                return baseResponse;
            }

            _seriesRepository.Delete(series.Result);
            baseResponse.Data = true;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponce<bool>()
            {
                Description = $"[GetFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public IBaseResponce<SeriesViewModel> CreateOneSeries(SeriesViewModel seriesViewModel)
    {
        var baseResponce = new BaseResponce<SeriesViewModel>();

        try
        {
            var seriesKinopoiskId = _context.Series.FirstOrDefault(x => x.KinopoiskId == seriesViewModel.KinopoiskId);

            if (seriesKinopoiskId != null)
            {
                throw new Exception("Series is exist");
            }

            var series = new Series()
            {
                KinopoiskId = seriesViewModel.KinopoiskId,
                Title = seriesViewModel.Title,
                Poster = seriesViewModel.Poster,
                Year = seriesViewModel.Year,
                Duration = seriesViewModel.Duration,
                Plot = seriesViewModel.Plot,
                KinopoiskRating = seriesViewModel.KinopoiskRating,
                YoutubeTrailer = seriesViewModel.YoutubeTrailer,
                ThumbnailUrl = seriesViewModel.ThumbnailUrl,
            };
            _seriesRepository.Create(series);

            if (seriesViewModel.SeriesCountriesList != null)
                foreach (var country in seriesViewModel.SeriesCountriesList)
                {
                    var nameCountry = _context.Countries.FirstOrDefault(x => x.Name == country.Name);

                    if (nameCountry == null)
                    {
                        _countryRepository.Create(new Country {Name = country.Name});
                        nameCountry = _countryRepository.GetByName(country.Name);
                    }

                    var idCountry = nameCountry.Id;

                    var seriesCountries = new SeriesCountries()
                    {
                        SeriesId = series.Id,
                        CountryId = idCountry,
                    };
                    _context.SeriesCountries.Add(seriesCountries);
                    _context.SaveChanges();
                }

            if (seriesViewModel.SeriesGenreList != null)
                foreach (var genre in seriesViewModel.SeriesGenreList)
                {
                    var nameGenre = _context.Genres.FirstOrDefault(x => x.Name == genre.Name);

                    if (nameGenre == null)
                    {
                        _genreRepository.Create(new Genre {Name = genre.Name});
                        nameGenre = _genreRepository.GetByName(genre.Name);
                    }

                    var idCountry = nameGenre.Id;

                    var seriesCountries = new SeriesGenres()
                    {
                        SeriesId = series.Id,
                        GenreId = idCountry,
                    };
                    _context.SeriesGenres.Add(seriesCountries);
                    _context.SaveChanges();
                }

            if (seriesViewModel.ActorsList != null)
                foreach (var name in seriesViewModel.ActorsList)
                {
                    var nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);

                    if (nameActor == null)
                    {
                        _actorRepository.Create(new Person()
                            {Name = name.Name, PersonKinopoiskId = name.ActorKinopoiskId});
                        nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
                    }

                    var idActors = nameActor.Id;

                    var seriesActors = new CharacterSeries()
                    {
                        SeriesId = series.Id,
                        ActorId = idActors,
                        Role = name.Role
                    };
                    _context.CharacterSeries.Add(seriesActors);
                    _context.SaveChanges();
                }

            // if (seriesViewModel.TopActorsList != null)
            //     foreach (var name in seriesViewModel.TopActorsList)
            //     {
            //         var nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
            //
            //         var idActors = nameActor.Id;
            //
            //         var filmsActors = new TopActor()
            //         {
            //             FilmId = series.Id,
            //             ActorId = idActors,
            //         };
            //         _context.TopActors.Add(filmsActors);
            //         _context.SaveChanges();
            //     }

            if (seriesViewModel.WritersList != null)
                foreach (var name in seriesViewModel.WritersList)
                {
                    var nameWriter =
                        _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.WriterKinopoiskId);

                    if (nameWriter == null)
                    {
                        _actorRepository.Create(new Person()
                            {Name = name.Name, PersonKinopoiskId = name.WriterKinopoiskId});
                        nameWriter =
                            _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.WriterKinopoiskId);
                    }

                    var idWriter = nameWriter.Id;

                    var seriesWriter = new WriterSeries()
                    {
                        SeriesId = series.Id,
                        WriterId = idWriter,
                    };
                    _context.WriterSeries.Add(seriesWriter);
                    _context.SaveChanges();
                }

            if (seriesViewModel.DirectorList != null)
                foreach (var name in seriesViewModel.DirectorList)
                {
                    var nameDirector =
                        _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.DirectorKinopoiskId);

                    if (nameDirector == null)
                    {
                        _actorRepository.Create(new Person()
                            {Name = name.Name, PersonKinopoiskId = name.DirectorKinopoiskId});
                        nameDirector =
                            _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.DirectorKinopoiskId);
                    }

                    var idWriter = nameDirector.Id;

                    var seriesDirector = new DirectorSeries()
                    {
                        SeriesId = series.Id,
                        DirectorId = idWriter,
                    };
                    _context.DirectorSeries.Add(seriesDirector);
                    _context.SaveChanges();
                }

            foreach (var season in seriesViewModel.SeasonViewModels)
            {
                var seasonNumber = new Season()
                {
                    SeriesId = series.Id,
                    NumberSeason = season.NumberSeason,
                };
                _context.Seasons.Add(seasonNumber);
                _context.SaveChanges();
                foreach (var episode in season.Episodes)
                {
                    var episodeNumber = new Episodes()
                    {
                        SeasonId = _context.Seasons.Where(x => x.NumberSeason == season.NumberSeason)
                            .Where(x => x.SeriesId == series.Id).FirstOrDefault().Id,
                        Image = episode.Image,
                        NumberEpisode = episode.NumberEpisode,
                        VideoLink = episode.VideoLink
                    };
                    _context.Episodes.Add(episodeNumber);
                    _context.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            return new BaseResponce<SeriesViewModel>()
            {
                Description = $"[GetFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }

    public IBaseResponce<SeriesViewModel> CreateSeries(List<SeriesViewModel> seriesViewModels)
    {
        var baseResponce = new BaseResponce<SeriesViewModel>();

        try
        {
            foreach (var seriesViewModel in seriesViewModels)
            {
                var seriesKinopoiskId =
                    _context.Series.FirstOrDefault(x => x.KinopoiskId == seriesViewModel.KinopoiskId);

                if (seriesKinopoiskId != null)
                {
                    throw new Exception("Series is exist");
                }

                var series = new Series()
                {
                    KinopoiskId = seriesViewModel.KinopoiskId,
                    Title = seriesViewModel.Title,
                    Poster = seriesViewModel.Poster,
                    Year = seriesViewModel.Year,
                    Duration = seriesViewModel.Duration,
                    Plot = seriesViewModel.Plot,
                    KinopoiskRating = seriesViewModel.KinopoiskRating,
                    YoutubeTrailer = seriesViewModel.YoutubeTrailer,
                    ThumbnailUrl = seriesViewModel.ThumbnailUrl,
                };
                _seriesRepository.Create(series);

                if (seriesViewModel.SeriesCountriesList != null)
                    foreach (var country in seriesViewModel.SeriesCountriesList)
                    {
                        var nameCountry = _context.Countries.FirstOrDefault(x => x.Name == country.Name);

                        if (nameCountry == null)
                        {
                            _countryRepository.Create(new Country {Name = country.Name});
                            nameCountry = _countryRepository.GetByName(country.Name);
                        }

                        var idCountry = nameCountry.Id;

                        var seriesCountries = new SeriesCountries()
                        {
                            SeriesId = series.Id,
                            CountryId = idCountry,
                        };
                        _context.SeriesCountries.Add(seriesCountries);
                        _context.SaveChanges();
                    }

                if (seriesViewModel.SeriesGenreList != null)
                    foreach (var genre in seriesViewModel.SeriesGenreList)
                    {
                        var nameGenre = _context.Genres.FirstOrDefault(x => x.Name == genre.Name);

                        if (nameGenre == null)
                        {
                            _genreRepository.Create(new Genre {Name = genre.Name});
                            nameGenre = _genreRepository.GetByName(genre.Name);
                        }

                        var idCountry = nameGenre.Id;

                        var seriesCountries = new SeriesGenres()
                        {
                            SeriesId = series.Id,
                            GenreId = idCountry,
                        };
                        _context.SeriesGenres.Add(seriesCountries);
                        _context.SaveChanges();
                    }

                if (seriesViewModel.ActorsList != null)
                    foreach (var name in seriesViewModel.ActorsList)
                    {
                        var nameActor =
                            _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);

                        if (nameActor == null)
                        {
                            _actorRepository.Create(new Person()
                                {Name = name.Name, PersonKinopoiskId = name.ActorKinopoiskId});
                            nameActor = _context.Persons.FirstOrDefault(x =>
                                x.PersonKinopoiskId == name.ActorKinopoiskId);
                        }

                        var idActors = nameActor.Id;

                        var seriesActors = new CharacterSeries()
                        {
                            SeriesId = series.Id,
                            ActorId = idActors,
                            Role = name.Role
                        };
                        _context.CharacterSeries.Add(seriesActors);
                        _context.SaveChanges();
                    }

                // if (seriesViewModel.TopActorsList != null)
                //     foreach (var name in seriesViewModel.TopActorsList)
                //     {
                //         var nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
                //
                //         var idActors = nameActor.Id;
                //
                //         var filmsActors = new TopActor()
                //         {
                //             FilmId = series.Id,
                //             ActorId = idActors,
                //         };
                //         _context.TopActors.Add(filmsActors);
                //         _context.SaveChanges();
                //     }

                if (seriesViewModel.WritersList != null)
                    foreach (var name in seriesViewModel.WritersList)
                    {
                        var nameWriter =
                            _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.WriterKinopoiskId);

                        if (nameWriter == null)
                        {
                            _actorRepository.Create(new Person()
                                {Name = name.Name, PersonKinopoiskId = name.WriterKinopoiskId});
                            nameWriter =
                                _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.WriterKinopoiskId);
                        }

                        var idWriter = nameWriter.Id;

                        var seriesWriter = new WriterSeries()
                        {
                            SeriesId = series.Id,
                            WriterId = idWriter,
                        };
                        _context.WriterSeries.Add(seriesWriter);
                        _context.SaveChanges();
                    }

                if (seriesViewModel.DirectorList != null)
                    foreach (var name in seriesViewModel.DirectorList)
                    {
                        var nameDirector =
                            _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.DirectorKinopoiskId);

                        if (nameDirector == null)
                        {
                            _actorRepository.Create(new Person()
                                {Name = name.Name, PersonKinopoiskId = name.DirectorKinopoiskId});
                            nameDirector =
                                _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.DirectorKinopoiskId);
                        }

                        var idWriter = nameDirector.Id;

                        var seriesDirector = new DirectorSeries()
                        {
                            SeriesId = series.Id,
                            DirectorId = idWriter,
                        };
                        _context.DirectorSeries.Add(seriesDirector);
                        _context.SaveChanges();
                    }
            }
        }
        catch (Exception ex)
        {
            return new BaseResponce<SeriesViewModel>()
            {
                Description = $"[GetFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }

    public IBaseResponce<SeriesViewModel> UpdateSeries(int id, SeriesViewModel filmViewModels)
    {
        throw new NotImplementedException();
    }
}