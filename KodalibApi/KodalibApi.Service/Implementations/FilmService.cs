using System.Transactions;
using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Interfaces.CountryInterfaces;
using KodalibApi.Interfaces.FilmIntefaces;
using KodalibApi.Interfaces.GenreInterfaces;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Filters;
using KodalibApi.Data.Models.VoiceoverTable;
using KodalibApi.Data.Response;
using KodalibApi.Data.Response.Enum;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.CreateViewModels;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Genre;
using KodalibApi.Interfaces.PeopleInterface;
using KodalibApi.Interfaces.Voiceover;

namespace Kodalib.Service.Implementations;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IVoiceoverRepository _voiceoverRepository;


    public FilmService(IFilmRepository filmRepository, ICountryRepository countryRepository,
        IGenreRepository genreRepository, IPersonRepository personRepository, IVoiceoverRepository voiceoverRepository)
    {
        _filmRepository = filmRepository;
        _countryRepository = countryRepository;
        _genreRepository = genreRepository;
        _personRepository = personRepository;
        _voiceoverRepository = voiceoverRepository;
    }

    public async Task<IBaseResponse> GetFilms(PageParameters pageParameters, FilmsFilters filmsFilters,
        CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<PagedList<FilmViewModels>>();

        try
        {
            var films = await _filmRepository.GetFilms(pageParameters, filmsFilters, cancellationToken);

            if (films == null || films.CurrentPage > films.TotalPages)
            {
                return new ErrorResponse()
                {
                    Description = "Films not found",
                    StatusCode = StatusCode.NotFound
                };
            }

            baseResponse.Data = films;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new ErrorResponse()
            {
                Description = $"[GetFilms] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse> GetLastFilms(CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<List<FilmViewModels>>();

        try
        {
            var films = await _filmRepository.GetLastFilms(cancellationToken);

            baseResponse.Data = films;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new ErrorResponse()
            {
                Description = $"[GetFilms] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse> GetFilmById(int id, CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<FilmViewModels>();

        try
        {
            var film = await _filmRepository.GetFilmById(id, cancellationToken);

            if (film == null)
            {
                return new ErrorResponse()
                {
                    Description = "Film not found",
                    StatusCode = StatusCode.NotFound
                };
            }

            baseResponse.Data = film;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new ErrorResponse()
            {
                Description = $"[GetFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse> CreateFilm(CreateFilmViewModel film, CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<IdViewModel>();

        try
        {
            //Country
            var countries = new List<CountryViewModel>();
            if (film.Countries != null)
            {
                foreach (var country in film.Countries)
                {
                    var countryModel = await _countryRepository.GetCountryByName(country, cancellationToken);

                    var countryId = new IdViewModel();

                    if (countryModel == null)
                    {
                        countryId = await _countryRepository.CreateCountry(country, cancellationToken);
                    }
                    else
                    {
                        countryId.Id = countryModel.Id;
                    }

                    countries.Add(new CountryViewModel()
                    {
                        Id = countryId.Id,
                        Name = country
                    });
                }
            }

            //Genre
            var genres = new List<GenreViewModel>();
            if (film.Genres != null)
            {
                foreach (var genre in film.Genres)
                {
                    var genreModel = await _genreRepository.GetGenreByName(genre, cancellationToken);

                    var genreId = new IdViewModel();

                    if (genreModel == null)
                    {
                        genreId = await _genreRepository.CreateGenre(genre, cancellationToken);
                    }
                    else
                    {
                        genreId.Id = genreModel.Id;
                    }

                    genres.Add(new GenreViewModel()
                    {
                        Id = genreId.Id,
                        Name = genre
                    });
                }
            }

            //Actor
            var actors = new List<CharacterViewModel>();
            if (film.Actors != null)
            {
                foreach (var actor in film.Actors)
                {
                    var actorModel = await _personRepository.GetPersonByName(actor, cancellationToken);

                    var actorId = new IdViewModel();

                    if (actorModel == null)
                    {
                        actorId = await _personRepository.CreatePerson(actor, cancellationToken);
                    }
                    else
                    {
                        actorId.Id = actorModel.Id;
                    }

                    actors.Add(new CharacterViewModel()
                    {
                        Id = actorId.Id,
                        Name = actor
                    });
                }
            }

            //Writer
            var writers = new List<CharacterViewModel>();
            if (film.Writers != null)
            {
                foreach (var writer in film.Writers)
                {
                    var writerModel = await _personRepository.GetPersonByName(writer, cancellationToken);

                    var writerId = new IdViewModel();

                    if (writerModel == null)
                    {
                        writerId = await _personRepository.CreatePerson(writer, cancellationToken);
                    }
                    else
                    {
                        writerId.Id = writerModel.Id;
                    }

                    writers.Add(new CharacterViewModel()
                    {
                        Id = writerId.Id,
                        Name = writer
                    });
                }
            }

            //Director
            var directors = new List<CharacterViewModel>();
            if (film.Directors != null)
            {
                foreach (var director in film.Directors)
                {
                    var directorModel = await _personRepository.GetPersonByName(director, cancellationToken);

                    var directorId = new IdViewModel();

                    if (directorModel == null)
                    {
                        directorId = await _personRepository.CreatePerson(director, cancellationToken);
                    }
                    else
                    {
                        directorId.Id = directorModel.Id;
                    }

                    directors.Add(new CharacterViewModel()
                    {
                        Id = directorId.Id,
                        Name = director
                    });
                }
            }

            //Voiceover
            var voiceovers = new List<VoiceoverFilmViewModel>();
            if (film.Voiceover != null)
            {
                foreach (var voiceover in film.Voiceover)
                {
                    var voiceoverModel =
                        await _voiceoverRepository.GetVoiceoverByName(voiceover.Name, cancellationToken);

                    var voiceoverId = new IdViewModel();

                    if (voiceoverModel == null)
                    {
                        voiceoverId = await _voiceoverRepository.CreateVoiceover(voiceover.Name, cancellationToken);
                    }
                    else
                    {
                        voiceoverId.Id = voiceoverModel.Id;
                    }

                    voiceovers.Add(new VoiceoverFilmViewModel()
                    {
                        Id = voiceoverId.Id,
                        Voiceover = voiceover.Name,
                        Link = voiceover.Link
                    });
                }
            }

            if (film.KinopoiskRating == "undefined")
                film.KinopoiskRating = "";
            
            FilmViewModels filmViewModels = new FilmViewModels()
            {
                Title = film.Title,
                Countries = countries,
                Genres = genres,
                Poster = film.Poster,
                Year = film.Year,
                Plot = film.Plot,
                YoutubeTrailer = film.YoutubeTrailer,
                KinopoiskRating = film.KinopoiskRating,
                KinopoiskId = film.KinopoiskId,
                Duration = film.Duration,
                Actors = actors,
                Directors = directors,
                Writers = writers,
                Voiceovers = voiceovers
            };

            var filmId = await _filmRepository.CreateFilm(filmViewModels, cancellationToken);

            baseResponse.Data = filmId;
            baseResponse.StatusCode = StatusCode.OK;
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

    public async Task CreateFilms(List<CreateFilmViewModel> films, CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<IdViewModel>();

        try
        {
            using var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions {IsolationLevel = IsolationLevel.RepeatableRead},
                TransactionScopeAsyncFlowOption.Enabled);

            foreach (var film in films)
            {
                try
                {
                    //Country
                    var countries = new List<CountryViewModel>();
                    if (film.Countries != null)
                    {
                        foreach (var country in film.Countries)
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
                    if (film.Genres != null)
                    {
                        foreach (var genre in film.Genres)
                        {
                            IdViewModel? genreId = null;

                            genreId = await _genreRepository.GetGenreIdByName(genre, cancellationToken)
                                      ?? await _genreRepository.CreateGenre(genre, cancellationToken);

                            if (!genres.Any(g => g.Id == genreId.Id))
                            {
                                genres.Add(new GenreViewModel()
                                {
                                    Id = genreId.Id,
                                    Name = genre
                                });
                            }
                        }
                    }

                    //Actor
                    var actors = new List<CharacterViewModel>();
                    if (film.Actors != null)
                    {
                        foreach (var actor in film.Actors)
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
                    if (film.Writers != null)
                    {
                        foreach (var writer in film.Writers)
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
                    if (film.Directors != null)
                    {
                        foreach (var director in film.Directors)
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
                    var voiceovers = new List<VoiceoverFilmViewModel>();
                    if (film.Voiceover != null)
                    {
                        foreach (var voiceover in film.Voiceover)
                        {
                            IdViewModel? voiceoverId = null;

                            voiceoverId =
                                await _voiceoverRepository.GetVoiceoverIdByName(voiceover.Name, cancellationToken)
                                ?? await _voiceoverRepository.CreateVoiceover(voiceover.Name, cancellationToken);

                            voiceovers.Add(new VoiceoverFilmViewModel()
                            {
                                Id = voiceoverId.Id,
                                Voiceover = voiceover.Name,
                                Link = voiceover.Link
                            });
                        }
                    }

                    if (film.KinopoiskRating == "undefined") film.KinopoiskRating = "";

                    FilmViewModels filmViewModels = new FilmViewModels()
                    {
                        Title = film.Title,
                        Countries = countries,
                        Genres = genres,
                        Poster = film.Poster,
                        Year = film.Year,
                        Plot = film.Plot,
                        YoutubeTrailer = film.YoutubeTrailer,
                        KinopoiskRating = film.KinopoiskRating,
                        KinopoiskId = film.KinopoiskId,
                        Duration = film.Duration,
                        Actors = actors,
                        Directors = directors,
                        Writers = writers,
                        Voiceovers = voiceovers
                    };

                    var filmId = await _filmRepository.CreateFilm(filmViewModels, cancellationToken);
                    baseResponse.Data = filmId;
                    baseResponse.StatusCode = StatusCode.OK;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            transaction.Complete();
        }
        catch (Exception ex)
        {
            new ErrorResponse()
            {
                Description = $"[CreateFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}