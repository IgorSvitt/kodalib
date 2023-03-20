using System.Transactions;
using GenelogyApi.Domain.ViewModels.Pages;
using Kodalib.Service.Interfaces;
using KodalibApi.Dal.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Models.PeopleTables.SeriesPeople;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.Response;
using KodalibApi.Data.Response.Enum;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.CreateViewModels;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Genre;
using KodalibApi.Data.ViewModels.Series;
using KodalibApi.Interfaces;
using KodalibApi.Interfaces.CountryInterfaces;
using KodalibApi.Interfaces.FilmIntefaces;
using KodalibApi.Interfaces.GenreInterfaces;
using KodalibApi.Interfaces.PeopleInterface;
using KodalibApi.Interfaces.Voiceover;

namespace Kodalib.Service.Implementations;

public class SeriesService : ISeriesService
{
    private readonly ISeriesRepository _seriesRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IVoiceoverRepository _voiceoverRepository;
    public SeriesService(ISeriesRepository seriesRepository, ICountryRepository countryRepository, IGenreRepository genreRepository, IPersonRepository personRepository, IVoiceoverRepository voiceoverRepository)
    {
        _seriesRepository = seriesRepository;
        _countryRepository = countryRepository;
        _genreRepository = genreRepository;
        _personRepository = personRepository;
        _voiceoverRepository = voiceoverRepository;
    }

    public async Task<IBaseResponse> GetSeries(PageParameters pageParameters, CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<PagedList<SeriesViewModel>>();

        try
        {
            var series = await _seriesRepository.GetSeries(pageParameters, cancellationToken);

            if (series == null || series.CurrentPage > series.TotalPages)
            {
                return new ErrorResponse()
                {
                    Description = "Series not found",
                    StatusCode = StatusCode.NotFound
                };
            }

            baseResponse.Data = series;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new ErrorResponse()
            {
                Description = $"[GetSeries] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse> GetSeriesById(int id, CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<SeriesViewModel>();

        try
        {
            var series = await _seriesRepository.GetSeriesById(id, cancellationToken);

            if (series == null)
            {
                return new ErrorResponse()
                {
                    Description = "Series not found",
                    StatusCode = StatusCode.NotFound
                };
            }

            baseResponse.Data = series;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new ErrorResponse()
            {
                Description = $"[GetSeries] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse> CreateSeries(List<CreateSeriesViewModel> series, CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<IdViewModel>();

        try
        {
            using var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions {IsolationLevel = IsolationLevel.RepeatableRead},
                TransactionScopeAsyncFlowOption.Enabled);
            
            foreach (var s in series)
            {
                //Country
                var countries = new List<CountryViewModel>();
                if (s.Countries != null)
                {
                    foreach (var country in s.Countries)
                    {
                        IdViewModel? countryId = null;

                        countryId = await _countryRepository.GetCountryIdByName(country, cancellationToken)
                                    ?? await _countryRepository.CreateCountry(country, cancellationToken);


                        countries.Add(new CountryViewModel()
                        {
                            Id = countryId.Id,
                            Name = country
                        });
                    }
                }

                //Genre
                var genres = new List<GenreViewModel>();
                if (s.Genres != null)
                {
                    foreach (var genre in s.Genres)
                    {
                        IdViewModel? genreId = null;

                        genreId = await _genreRepository.GetGenreIdByName(genre, cancellationToken)
                                  ?? await _genreRepository.CreateGenre(genre, cancellationToken);

                        genres.Add(new GenreViewModel()
                        {
                            Id = genreId.Id,
                            Name = genre
                        });
                    }
                }

                //Actor
                var actors = new List<CharacterViewModel>();
                if (s.Actors != null)
                {
                    foreach (var actor in s.Actors)
                    {
                        IdViewModel? actorId = null;

                        actorId = await _personRepository.GetPersonIdByName(actor, cancellationToken)
                                  ?? await _personRepository.CreatePerson(actor, cancellationToken);

                        actors.Add(new CharacterViewModel()
                        {
                            Id = actorId.Id,
                            Name = actor
                        });
                    }
                }

                //Writer
                var writers = new List<CharacterViewModel>();
                if (s.Writers != null)
                {
                    foreach (var writer in s.Writers)
                    {
                        IdViewModel? writerId = null;

                        writerId = await _personRepository.GetPersonIdByName(writer, cancellationToken)
                                   ?? await _personRepository.CreatePerson(writer, cancellationToken);

                        writers.Add(new CharacterViewModel()
                        {
                            Id = writerId.Id,
                            Name = writer
                        });
                    }
                }

                //Director
                var directors = new List<CharacterViewModel>();
                if (s.Directors != null)
                {
                    foreach (var director in s.Directors)
                    {
                        IdViewModel? directorId = null;

                        directorId = await _personRepository.GetPersonIdByName(director, cancellationToken)
                                     ?? await _personRepository.CreatePerson(director, cancellationToken);

                        directors.Add(new CharacterViewModel()
                        {
                            Id = directorId.Id,
                            Name = director
                        });
                    }
                }

                //Voiceover
                var voiceovers = new List<SeriesVoiceoverViewModel>();
                if (s.Voiceover != null)
                {
                    foreach (var voiceover in s.Voiceover)
                    {
                        IdViewModel? voiceoverId = null;

                        voiceoverId =
                            await _voiceoverRepository.GetVoiceoverIdByName(voiceover.Name, cancellationToken)
                            ?? await _voiceoverRepository.CreateVoiceover(voiceover.Name, cancellationToken);

                        voiceovers.Add(new SeriesVoiceoverViewModel()
                        {
                            Id = voiceoverId.Id,
                            Voiceover = voiceover.Name,
                            CountEpisodes = voiceover.CountEpisodes,
                            CountSeasons = voiceover.CountSeason,
                            Seasons = voiceover.Season
                        });
                    }
                }

                SeriesViewModel filmViewModels = new SeriesViewModel()
                {
                    Title = s.Title,
                    Countries = countries,
                    Genres = genres,
                    Poster = s.Poster,
                    Year = s.Year,
                    Plot = s.Plot,
                    YoutubeTrailer = s.YoutubeTrailer,
                    KinopoiskRating = s.KinopoiskRating,
                    KinopoiskId = s.KinopoiskId,
                    Duration = s.Duration,
                    Actors = actors,
                    Directors = directors,
                    Writers = writers,
                    Voiceovers = voiceovers
                };

                var seriesId = await _seriesRepository.CreateSeries(filmViewModels, cancellationToken);
                baseResponse.Data = seriesId;
                baseResponse.StatusCode = StatusCode.OK;
            }
            transaction.Complete();
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new ErrorResponse()
            {
                Description = $"[CreateFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    // public IBaseResponce<IEnumerable<SeriesViewModel>> GetSeries()
    // {
    //     var baseResponse = new BaseResponce<IEnumerable<SeriesViewModel>>();
    //
    //     try
    //     {
    //         var series = _seriesRepository.GetAllSeries();
    //         if (series.Result.Count == 0)
    //         {
    //             baseResponse.Description = "Found 0 elements";
    //             baseResponse.StatusCode = StatusCode.OK;
    //             return baseResponse;
    //         }
    //
    //         baseResponse.Data = series.Result;
    //         baseResponse.StatusCode = StatusCode.OK;
    //
    //
    //         return baseResponse;
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<IEnumerable<SeriesViewModel>>()
    //         {
    //             Description = $"[GetFilms] : {ex.Message}"
    //         };
    //     }
    // }
    //
    // public IBaseResponce<SeriesViewModel> GetOneSeries(int id)
    // {
    //     var baseResponse = new BaseResponce<SeriesViewModel>();
    //
    //     try
    //     {
    //         var series = _seriesRepository.GetByIdFullDescription(id);
    //         if (series.Result == null)
    //         {
    //             baseResponse.Description = "Found 0 elements";
    //             baseResponse.StatusCode = StatusCode.OK;
    //             return baseResponse;
    //         }
    //
    //         foreach (var season in series.Result.SeasonViewModels)
    //         {
    //             series.Result.CountEpisodes += season.Episodes.Count;
    //         }
    //
    //         baseResponse.Data = series.Result;
    //         baseResponse.StatusCode = StatusCode.OK;
    //
    //
    //         return baseResponse;
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<SeriesViewModel>()
    //         {
    //             Description = $"[GetFilms] : {ex.Message}"
    //         };
    //     }
    // }
    //
    // public IBaseResponce<Series> GetSeriesByName(string name)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public IBaseResponce<bool> DeleteSeries(int id)
    // {
    //     var baseResponse = new BaseResponce<bool>();
    //
    //     try
    //     {
    //         var series = _seriesRepository.GetById(id);
    //         if (series == null)
    //         {
    //             baseResponse.Description = "Series not found";
    //             baseResponse.StatusCode = StatusCode.SeriesNotFound;
    //             baseResponse.Data = false;
    //             return baseResponse;
    //         }
    //
    //         _seriesRepository.Delete(series.Result);
    //         baseResponse.Data = true;
    //         return baseResponse;
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<bool>()
    //         {
    //             Description = $"[GetFilm] : {ex.Message}",
    //             StatusCode = StatusCode.InternalServerError
    //         };
    //     }
    // }
    //
    // public IBaseResponce<SeriesViewModel> CreateOneSeries(SeriesViewModel seriesViewModel)
    // {
    //     var baseResponce = new BaseResponce<SeriesViewModel>();
    //
    //     try
    //     {
    //         var seriesKinopoiskId = _context.Series.FirstOrDefault(x => x.KinopoiskId == seriesViewModel.KinopoiskId);
    //
    //         if (seriesKinopoiskId != null)
    //         {
    //             throw new Exception("Series is exist");
    //         }
    //
    //         var series = new Series()
    //         {
    //             KinopoiskId = seriesViewModel.KinopoiskId,
    //             Title = seriesViewModel.Title,
    //             Poster = seriesViewModel.Poster,
    //             Year = seriesViewModel.Year,
    //             Duration = seriesViewModel.Duration,
    //             Plot = seriesViewModel.Plot,
    //             KinopoiskRating = seriesViewModel.KinopoiskRating,
    //             YoutubeTrailer = seriesViewModel.YoutubeTrailer,
    //             ThumbnailUrl = seriesViewModel.ThumbnailUrl,
    //         };
    //         _seriesRepository.Create(series);
    //
    //         if (seriesViewModel.SeriesCountriesList != null)
    //             foreach (var country in seriesViewModel.SeriesCountriesList)
    //             {
    //                 var nameCountry = _context.Countries.FirstOrDefault(x => x.Name == country.Name);
    //
    //                 if (nameCountry == null)
    //                 {
    //                     _countryRepository.Create(new Country {Name = country.Name});
    //                     nameCountry = _countryRepository.GetByName(country.Name);
    //                 }
    //
    //                 var idCountry = nameCountry.Id;
    //
    //                 var seriesCountries = new SeriesCountries()
    //                 {
    //                     SeriesId = series.Id,
    //                     CountryId = idCountry,
    //                 };
    //                 _context.SeriesCountries.Add(seriesCountries);
    //                 _context.SaveChanges();
    //             }
    //
    //         if (seriesViewModel.SeriesGenreList != null)
    //             foreach (var genre in seriesViewModel.SeriesGenreList)
    //             {
    //                 var nameGenre = _context.Genres.FirstOrDefault(x => x.Name == genre.Name);
    //
    //                 if (nameGenre == null)
    //                 {
    //                     _genreRepository.Create(new Genre {Name = genre.Name});
    //                     nameGenre = _genreRepository.GetByName(genre.Name);
    //                 }
    //
    //                 var idCountry = nameGenre.Id;
    //
    //                 var seriesCountries = new SeriesGenres()
    //                 {
    //                     SeriesId = series.Id,
    //                     GenreId = idCountry,
    //                 };
    //                 _context.SeriesGenres.Add(seriesCountries);
    //                 _context.SaveChanges();
    //             }
    //
    //         if (seriesViewModel.ActorsList != null)
    //             foreach (var name in seriesViewModel.ActorsList)
    //             {
    //                 var nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
    //
    //                 if (nameActor == null)
    //                 {
    //                     _actorRepository.Create(new Person()
    //                         {Name = name.Name, PersonKinopoiskId = name.ActorKinopoiskId});
    //                     nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
    //                 }
    //
    //                 var idActors = nameActor.Id;
    //
    //                 var seriesActors = new CharacterSeries()
    //                 {
    //                     SeriesId = series.Id,
    //                     ActorId = idActors,
    //                     Role = name.Role
    //                 };
    //                 _context.CharacterSeries.Add(seriesActors);
    //                 _context.SaveChanges();
    //             }
    //
    //         // if (seriesViewModel.TopActorsList != null)
    //         //     foreach (var name in seriesViewModel.TopActorsList)
    //         //     {
    //         //         var nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
    //         //
    //         //         var idActors = nameActor.Id;
    //         //
    //         //         var filmsActors = new TopActor()
    //         //         {
    //         //             FilmId = series.Id,
    //         //             ActorId = idActors,
    //         //         };
    //         //         _context.TopActors.Add(filmsActors);
    //         //         _context.SaveChanges();
    //         //     }
    //
    //         if (seriesViewModel.WritersList != null)
    //             foreach (var name in seriesViewModel.WritersList)
    //             {
    //                 var nameWriter =
    //                     _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.WriterKinopoiskId);
    //
    //                 if (nameWriter == null)
    //                 {
    //                     _actorRepository.Create(new Person()
    //                         {Name = name.Name, PersonKinopoiskId = name.WriterKinopoiskId});
    //                     nameWriter =
    //                         _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.WriterKinopoiskId);
    //                 }
    //
    //                 var idWriter = nameWriter.Id;
    //
    //                 var seriesWriter = new WriterSeries()
    //                 {
    //                     SeriesId = series.Id,
    //                     WriterId = idWriter,
    //                 };
    //                 _context.WriterSeries.Add(seriesWriter);
    //                 _context.SaveChanges();
    //             }
    //
    //         if (seriesViewModel.DirectorList != null)
    //             foreach (var name in seriesViewModel.DirectorList)
    //             {
    //                 var nameDirector =
    //                     _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.DirectorKinopoiskId);
    //
    //                 if (nameDirector == null)
    //                 {
    //                     _actorRepository.Create(new Person()
    //                         {Name = name.Name, PersonKinopoiskId = name.DirectorKinopoiskId});
    //                     nameDirector =
    //                         _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.DirectorKinopoiskId);
    //                 }
    //
    //                 var idWriter = nameDirector.Id;
    //
    //                 var seriesDirector = new DirectorSeries()
    //                 {
    //                     SeriesId = series.Id,
    //                     DirectorId = idWriter,
    //                 };
    //                 _context.DirectorSeries.Add(seriesDirector);
    //                 _context.SaveChanges();
    //             }
    //
    //         foreach (var season in seriesViewModel.SeasonViewModels)
    //         {
    //             var seasonNumber = new Season()
    //             {
    //                 SeriesId = series.Id,
    //                 NumberSeason = season.NumberSeason,
    //             };
    //             _context.Seasons.Add(seasonNumber);
    //             _context.SaveChanges();
    //             foreach (var episode in season.Episodes)
    //             {
    //                 var episodeNumber = new Episodes()
    //                 {
    //                     SeasonId = _context.Seasons.Where(x => x.NumberSeason == season.NumberSeason)
    //                         .Where(x => x.SeriesId == series.Id).FirstOrDefault().Id,
    //                     Image = episode.Image,
    //                     NumberEpisode = episode.NumberEpisode,
    //                     VideoLink = episode.VideoLink
    //                 };
    //                 _context.Episodes.Add(episodeNumber);
    //                 _context.SaveChanges();
    //             }
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<SeriesViewModel>()
    //         {
    //             Description = $"[GetFilm] : {ex.Message}",
    //             StatusCode = StatusCode.InternalServerError
    //         };
    //     }
    //
    //     return baseResponce;
    // }
    //
    // public IBaseResponce<SeriesViewModel> CreateSeries(List<SeriesViewModel> seriesViewModels)
    // {
    //     var baseResponce = new BaseResponce<SeriesViewModel>();
    //
    //     try
    //     {
    //         foreach (var seriesViewModel in seriesViewModels)
    //         {
    //             
    //             var seriesKinopoiskId =
    //                 _context.Series.FirstOrDefault(x => x.KinopoiskId == seriesViewModel.KinopoiskId);
    //
    //             if (seriesKinopoiskId != null)
    //             {
    //                 continue;
    //             }
    //
    //             var series = new Series()
    //             {
    //                 KinopoiskId = seriesViewModel.KinopoiskId,
    //                 Title = seriesViewModel.Title,
    //                 Poster = seriesViewModel.Poster,
    //                 Year = seriesViewModel.Year,
    //                 Duration = seriesViewModel.Duration,
    //                 Plot = seriesViewModel.Plot,
    //                 KinopoiskRating = seriesViewModel.KinopoiskRating,
    //                 YoutubeTrailer = seriesViewModel.YoutubeTrailer,
    //                 ThumbnailUrl = seriesViewModel.ThumbnailUrl,
    //             };
    //             _seriesRepository.Create(series);
    //
    //             if (seriesViewModel.SeriesCountriesList != null)
    //                 foreach (var country in seriesViewModel.SeriesCountriesList)
    //                 {
    //                     var nameCountry = _context.Countries.FirstOrDefault(x => x.Name == country.Name);
    //
    //                     if (nameCountry == null)
    //                     {
    //                         _countryRepository.Create(new Country {Name = country.Name});
    //                         nameCountry = _countryRepository.GetByName(country.Name);
    //                     }
    //
    //                     var idCountry = nameCountry.Id;
    //
    //                     var seriesCountries = new SeriesCountries()
    //                     {
    //                         SeriesId = series.Id,
    //                         CountryId = idCountry,
    //                     };
    //                     _context.SeriesCountries.Add(seriesCountries);
    //                     _context.SaveChanges();
    //                 }
    //
    //             if (seriesViewModel.SeriesGenreList != null)
    //                 foreach (var genre in seriesViewModel.SeriesGenreList)
    //                 {
    //                     var nameGenre = _context.Genres.FirstOrDefault(x => x.Name == genre.Name);
    //
    //                     if (nameGenre == null)
    //                     {
    //                         _genreRepository.Create(new Genre {Name = genre.Name});
    //                         nameGenre = _genreRepository.GetByName(genre.Name);
    //                     }
    //
    //                     var idCountry = nameGenre.Id;
    //
    //                     var seriesCountries = new SeriesGenres()
    //                     {
    //                         SeriesId = series.Id,
    //                         GenreId = idCountry,
    //                     };
    //                     _context.SeriesGenres.Add(seriesCountries);
    //                     _context.SaveChanges();
    //                 }
    //
    //             if (seriesViewModel.ActorsList != null)
    //                 foreach (var name in seriesViewModel.ActorsList)
    //                 {
    //                     var nameActor =
    //                         _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
    //
    //                     if (nameActor == null)
    //                     {
    //                         _actorRepository.Create(new Person()
    //                             {Name = name.Name, PersonKinopoiskId = name.ActorKinopoiskId});
    //                         nameActor = _context.Persons.FirstOrDefault(x =>
    //                             x.PersonKinopoiskId == name.ActorKinopoiskId);
    //                     }
    //
    //                     var idActors = nameActor.Id;
    //
    //                     var seriesActors = new CharacterSeries()
    //                     {
    //                         SeriesId = series.Id,
    //                         ActorId = idActors,
    //                         Role = name.Role
    //                     };
    //                     _context.CharacterSeries.Add(seriesActors);
    //                     _context.SaveChanges();
    //                 }
    //
    //             // if (seriesViewModel.TopActorsList != null)
    //             //     foreach (var name in seriesViewModel.TopActorsList)
    //             //     {
    //             //         var nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
    //             //
    //             //         var idActors = nameActor.Id;
    //             //
    //             //         var filmsActors = new TopActor()
    //             //         {
    //             //             FilmId = series.Id,
    //             //             ActorId = idActors,
    //             //         };
    //             //         _context.TopActors.Add(filmsActors);
    //             //         _context.SaveChanges();
    //             //     }
    //
    //             if (seriesViewModel.WritersList != null)
    //                 foreach (var name in seriesViewModel.WritersList)
    //                 {
    //                     var nameWriter =
    //                         _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.WriterKinopoiskId);
    //
    //                     if (nameWriter == null)
    //                     {
    //                         _actorRepository.Create(new Person()
    //                             {Name = name.Name, PersonKinopoiskId = name.WriterKinopoiskId});
    //                         nameWriter =
    //                             _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.WriterKinopoiskId);
    //                     }
    //
    //                     var idWriter = nameWriter.Id;
    //
    //                     var seriesWriter = new WriterSeries()
    //                     {
    //                         SeriesId = series.Id,
    //                         WriterId = idWriter,
    //                     };
    //                     _context.WriterSeries.Add(seriesWriter);
    //                     _context.SaveChanges();
    //                 }
    //
    //             if (seriesViewModel.DirectorList != null)
    //                 foreach (var name in seriesViewModel.DirectorList)
    //                 {
    //                     var nameDirector =
    //                         _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.DirectorKinopoiskId);
    //
    //                     if (nameDirector == null)
    //                     {
    //                         _actorRepository.Create(new Person()
    //                             {Name = name.Name, PersonKinopoiskId = name.DirectorKinopoiskId});
    //                         nameDirector =
    //                             _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.DirectorKinopoiskId);
    //                     }
    //
    //                     var idWriter = nameDirector.Id;
    //
    //                     var seriesDirector = new DirectorSeries()
    //                     {
    //                         SeriesId = series.Id,
    //                         DirectorId = idWriter,
    //                     };
    //                     _context.DirectorSeries.Add(seriesDirector);
    //                     _context.SaveChanges();
    //                 }
    //             foreach (var season in seriesViewModel.SeasonViewModels)
    //             {
    //                 var seasonNumber = new Season()
    //                 {
    //                     SeriesId = series.Id,
    //                     NumberSeason = season.NumberSeason,
    //                 };
    //                 _context.Seasons.Add(seasonNumber);
    //                 _context.SaveChanges();
    //                 foreach (var episode in season.Episodes)
    //                 {
    //                     var episodeNumber = new Episodes()
    //                     {
    //                         SeasonId = _context.Seasons.Where(x => x.NumberSeason == season.NumberSeason)
    //                             .Where(x => x.SeriesId == series.Id).FirstOrDefault().Id,
    //                         Image = episode.Image,
    //                         NumberEpisode = episode.NumberEpisode,
    //                         VideoLink = episode.VideoLink
    //                     };
    //                     _context.Episodes.Add(episodeNumber);
    //                     _context.SaveChanges();
    //                 }
    //             }
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<SeriesViewModel>()
    //         {
    //             Description = $"[GetFilm] : {ex.Message}",
    //             StatusCode = StatusCode.InternalServerError
    //         };
    //     }
    //
    //     return baseResponce;
    // }
    //
    // public IBaseResponce<SeriesViewModel> UpdateSeries(int id, SeriesViewModel filmViewModels)
    // {
    //     throw new NotImplementedException();
    // }
    
}