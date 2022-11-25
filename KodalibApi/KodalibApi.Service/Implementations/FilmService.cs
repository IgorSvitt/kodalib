using KodalibApi.Interfaces.Base;
using KodalibApi.Interfaces.CountryInterfaces;
using KodalibApi.Interfaces.FilmIntefaces;
using KodalibApi.Interfaces.GenreInterfaces;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Interfaces.PeopleInterface;

namespace Kodalib.Service.Implementations;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;
    private readonly ApplicationDbContext _context;
    private readonly ICountryRepository _countryRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPersonRepository _actorRepository;


    public FilmService(IFilmRepository filmRepository, ApplicationDbContext context,
        ICountryRepository countryRepository,
        IGenreRepository genreRepository, IPersonRepository actorRepository)
    {
        _filmRepository = filmRepository;
        _context = context;
        _countryRepository = countryRepository;
        _genreRepository = genreRepository;
        _actorRepository = actorRepository;
    }

    public IBaseResponce<IEnumerable<FilmViewModels>> GetFilms()
    {
        var baseResponce = new BaseResponce<IEnumerable<FilmViewModels>>();

        try
        {
            var films = _filmRepository.GetAllFilms();
            if (films.Result.Count == 0)
            {
                baseResponce.Description = "Found 0 elements";
                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }

            baseResponce.Data = films.Result;
            baseResponce.StatusCode = StatusCode.OK;


            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<IEnumerable<FilmViewModels>>()
            {
                Description = $"[GetFilms] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<FilmViewModels> GetFilm(int id)
    {
        var baseResponce = new BaseResponce<FilmViewModels>();

        try
        {
            var film = _filmRepository.GetByIdFullDescription(id);
            if (film == null)
            {
                baseResponce.Description = "Film not found";
                baseResponce.StatusCode = StatusCode.FilmNotFound;
                return baseResponce;
            }

            baseResponce.Data = film.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<FilmViewModels>()
            {
                Description = $"[GetFilm] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<Film> GetFilmByName(string name)
    {
        throw new NotImplementedException();
    }

    public IBaseResponce<bool> DeleteFilms(int id)
    {
        var baseResponse = new BaseResponce<bool>();

        try
        {
            var film = _filmRepository.GetById(id);
            if (film == null)
            {
                baseResponse.Description = "Film not found";
                baseResponse.StatusCode = StatusCode.FilmNotFound;
                baseResponse.Data = false;
                return baseResponse;
            }

            _filmRepository.Delete(film.Result);
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

    public IBaseResponce<Film> CreateFilm(FilmViewModels filmViewModels)
    {
        var baseResponce = new BaseResponce<Film>();

        try
        {
            var filmImdbId = _context.Films.FirstOrDefault(x => x.ImdbId == filmViewModels.ImdbId);

            if (filmImdbId != null)
            {
                throw new Exception("Film is exist");
            }

            var film = new Film()
            {
                ImdbId = filmViewModels.ImdbId,
                Title = filmViewModels.Title,
                Poster = filmViewModels.Poster,
                Year = filmViewModels.Year,
                Duration = filmViewModels.Duration,
                Plot = filmViewModels.Plot,
                ImdbRating = filmViewModels.ImdbRating,
                Budget = filmViewModels.Budget,
                GrossWorldwide = filmViewModels.GrossWorldwide,
                YoutubeTrailer = filmViewModels.YoutubeTrailer,
            };
            _filmRepository.Create(film);

            foreach (var name in filmViewModels.FilmsCountriesList)
            {
                var nameCountry = _countryRepository.GetByName(name);

                if (nameCountry == null)
                {
                    _countryRepository.Create(new Country {Name = name});
                    nameCountry = _countryRepository.GetByName(name);
                }

                var idCountry = nameCountry.Id;

                var filmsCountries = new FilmsCountries()
                {
                    FilmsId = film.Id,
                    CountryId = idCountry,
                };
                _context.FilmsCountriesEnumerable.Add(filmsCountries);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.FilmsGenreList)
            {
                var nameGenre = _genreRepository.GetByName(name);

                if (nameGenre == null)
                {
                    _genreRepository.Create(new Genre {Name = name});
                    nameGenre = _genreRepository.GetByName(name);
                }

                var idCountry = nameGenre.Id;

                var filmsGenres = new FilmsGenres()
                {
                    FilmsId = film.Id,
                    GenreId = idCountry,
                };
                _context.FilmsGenresEnumerable.Add(filmsGenres);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.ActorsList)
            {
                var nameActor = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.ActorImdbId);

                if (nameActor == null)
                {
                    _actorRepository.Create(new Person() {Name = name.Actor, PersonImdbId = name.ActorImdbId});
                    nameActor = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.ActorImdbId);
                }

                var idActors = nameActor.Id;

                var filmsActors = new Character()
                {
                    FilmId = film.Id,
                    ActorId = idActors,
                    Role = name.Role
                };
                _context.Characters.Add(filmsActors);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.TopActorsList)
            {
                var nameActor = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.ActorImdbId);

                var idActors = nameActor.Id;

                var filmsActors = new TopActor()
                {
                    FilmId = film.Id,
                    ActorId = idActors,
                };
                _context.TopActors.Add(filmsActors);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.WritersList)
            {
                var nameWriter = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.WriterImdbId);

                if (nameWriter == null)
                {
                    _actorRepository.Create(new Person() {Name = name.Writer, PersonImdbId = name.WriterImdbId});
                    nameWriter = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.WriterImdbId);
                }

                var idWriter = nameWriter.Id;

                var filmsWriter = new Writers()
                {
                    FilmId = film.Id,
                    WriterId = idWriter,
                };
                _context.Writers.Add(filmsWriter);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.DirectorList)
            {
                var nameDirector = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.DirectorImdbId);

                if (nameDirector == null)
                {
                    _actorRepository.Create(new Person() {Name = name.Director, PersonImdbId = name.DirectorImdbId});
                    nameDirector = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.DirectorImdbId);
                }

                var idWriter = nameDirector.Id;

                var filmsDirector = new Director()
                {
                    FilmId = film.Id,
                    DirectorId = idWriter,
                };
                _context.Directors.Add(filmsDirector);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            return new BaseResponce<Film>()
            {
                Description = $"[GetFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }

    public IBaseResponce<FilmViewModels> UpdateFilm(int id, FilmViewModels filmViewModels)
    {
        var baseResponce = new BaseResponce<FilmViewModels>();

        try
        {
            var film = _filmRepository.GetById(id);

            if (film == null)
            {
                CreateFilm(filmViewModels);
                return baseResponce;
            }

            film.Result.Title = filmViewModels.Title;
            film.Result.Poster = filmViewModels.Poster;
            film.Result.Year = filmViewModels.Year;
            film.Result.Duration = filmViewModels.Duration;
            film.Result.Plot = filmViewModels.Plot;
            film.Result.ImdbRating = filmViewModels.ImdbRating;
            film.Result.Budget = filmViewModels.Budget;
            film.Result.GrossWorldwide = filmViewModels.GrossWorldwide;
            film.Result.YoutubeTrailer = filmViewModels.YoutubeTrailer;
            _filmRepository.Update(film.Result);

            foreach (var name in filmViewModels.FilmsCountriesList)
            {
                var nameCountry = _countryRepository.GetByName(name);

                if (nameCountry == null)
                {
                    _countryRepository.Create(new Country {Name = name});
                    nameCountry = _countryRepository.GetByName(name);
                }

                var idCountry = nameCountry.Id;

                var filmsCountries = new FilmsCountries()
                {
                    FilmsId = film.Id,
                    CountryId = idCountry,
                };
                _context.FilmsCountriesEnumerable.Add(filmsCountries);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.FilmsGenreList)
            {
                var nameGenre = _genreRepository.GetByName(name);

                if (nameGenre == null)
                {
                    _genreRepository.Create(new Genre {Name = name});
                    nameGenre = _genreRepository.GetByName(name);
                }

                var idCountry = nameGenre.Id;

                var filmsGenres = new FilmsGenres()
                {
                    FilmsId = film.Id,
                    GenreId = idCountry,
                };
                _context.FilmsGenresEnumerable.Add(filmsGenres);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.ActorsList)
            {
                var nameActor = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.ActorImdbId);

                if (nameActor == null)
                {
                    _actorRepository.Create(new Person() {Name = name.Actor, PersonImdbId = name.ActorImdbId});
                    nameActor = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.ActorImdbId);
                }

                var idActors = nameActor.Id;

                var filmsActors = new Character()
                {
                    FilmId = film.Id,
                    ActorId = idActors,
                    Role = name.Role
                };
                _context.Characters.Add(filmsActors);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.TopActorsList)
            {
                var nameActor = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.ActorImdbId);

                var idActors = nameActor.Id;

                var filmsActors = new TopActor()
                {
                    FilmId = film.Id,
                    ActorId = idActors,
                };
                _context.TopActors.Add(filmsActors);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.WritersList)
            {
                var nameWriter = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.WriterImdbId);

                if (nameWriter == null)
                {
                    _actorRepository.Create(new Person() {Name = name.Writer, PersonImdbId = name.WriterImdbId});
                    nameWriter = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.WriterImdbId);
                }

                var idWriter = nameWriter.Id;

                var filmsWriter = new Writers()
                {
                    FilmId = film.Id,
                    WriterId = idWriter,
                };
                _context.Writers.Add(filmsWriter);
                _context.SaveChanges();
            }

            foreach (var name in filmViewModels.DirectorList)
            {
                var nameDirector = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.DirectorImdbId);

                if (nameDirector == null)
                {
                    _actorRepository.Create(new Person() {Name = name.Director, PersonImdbId = name.DirectorImdbId});
                    nameDirector = _context.Persons.FirstOrDefault(x => x.PersonImdbId == name.DirectorImdbId);
                }

                var idWriter = nameDirector.Id;

                var filmsDirector = new Director()
                {
                    FilmId = film.Id,
                    DirectorId = idWriter,
                };
                _context.Directors.Add(filmsDirector);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            return new BaseResponce<FilmViewModels>()
            {
                Description = $"[GetFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }
}