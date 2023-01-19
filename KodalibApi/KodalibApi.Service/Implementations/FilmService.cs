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
            if (film.Result == null)
            {
                baseResponce.Description = "Film not found";
                baseResponce.StatusCode = StatusCode.FilmNotFound;
                return baseResponce;
            }

            baseResponce.StatusCode = StatusCode.OK;
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
            var filmImdbId = _context.Films.FirstOrDefault(x => x.KinopoiskId == filmViewModels.KinopoiskId);

            if (filmImdbId != null)
            {
                throw new Exception("Film is exist");
            }

            var film = new Film()
            {
                KinopoiskId = filmViewModels.KinopoiskId,
                Title = filmViewModels.Title,
                Poster = filmViewModels.Poster,
                LinkVideo = filmViewModels.LinkVideo,
                Year = filmViewModels.Year,
                Duration = filmViewModels.Duration,
                Plot = filmViewModels.Plot,
                KinopoiskRating = filmViewModels.KinopoiskRating,
                YoutubeTrailer = filmViewModels.YoutubeTrailer,
                ThumbnailUrl = filmViewModels.ThumbnailUrl,
            };
            _filmRepository.Create(film);

            if (filmViewModels.FilmsCountriesList != null)
                foreach (var country in filmViewModels.FilmsCountriesList)
                {
                    var nameCountry = _context.Countries.FirstOrDefault(x => x.Name == country.Name);

                    if (nameCountry == null)
                    {
                        _countryRepository.Create(new Country {Name = country.Name});
                        nameCountry = _countryRepository.GetByName(country.Name);
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

            if (filmViewModels.FilmsGenreList != null)
                foreach (var genre in filmViewModels.FilmsGenreList)
                {
                    var nameGenre = _context.Genres.FirstOrDefault(x => x.Name == genre.Name);

                    if (nameGenre == null)
                    {
                        _genreRepository.Create(new Genre {Name = genre.Name});
                        nameGenre = _genreRepository.GetByName(genre.Name);
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

            if (filmViewModels.ActorsList != null)
                foreach (var name in filmViewModels.ActorsList)
                {
                    var nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);

                    if (nameActor == null)
                    {
                        _actorRepository.Create(new Person()
                            {Name = name.Name, PersonKinopoiskId = name.ActorKinopoiskId});
                        nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
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

            if (filmViewModels.TopActorsList != null)
                foreach (var name in filmViewModels.TopActorsList)
                {
                    var nameActor = _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);

                    var idActors = nameActor.Id;

                    var filmsActors = new TopActor()
                    {
                        FilmId = film.Id,
                        ActorId = idActors,
                    };
                    _context.TopActors.Add(filmsActors);
                    _context.SaveChanges();
                }

            if (filmViewModels.WritersList != null)
                foreach (var name in filmViewModels.WritersList)
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

                    var filmsWriter = new Writers()
                    {
                        FilmId = film.Id,
                        WriterId = idWriter,
                    };
                    _context.Writers.Add(filmsWriter);
                    _context.SaveChanges();
                }

            if (filmViewModels.DirectorList != null)
                foreach (var name in filmViewModels.DirectorList)
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
    
    public IBaseResponce<Film> CreateFilms(List<FilmViewModels> filmViewModelsList)
    {
        var baseResponce = new BaseResponce<Film>();

        try
        {
            foreach (var filmViewModel in filmViewModelsList)

            {
                var filmImdbId = _context.Films.FirstOrDefault(x => x.KinopoiskId == filmViewModel.KinopoiskId);

                if (filmImdbId != null)
                {
                    continue;
                }

                var film = new Film()
                {
                    KinopoiskId = filmViewModel.KinopoiskId,
                    Title = filmViewModel.Title,
                    Poster = filmViewModel.Poster,
                    LinkVideo = filmViewModel.LinkVideo,
                    Year = filmViewModel.Year,
                    Duration = filmViewModel.Duration,
                    Plot = filmViewModel.Plot,
                    KinopoiskRating = filmViewModel.KinopoiskRating,
                    YoutubeTrailer = filmViewModel.YoutubeTrailer,
                    ThumbnailUrl = filmViewModel.ThumbnailUrl,
                };
                _filmRepository.Create(film);
                
                if (filmViewModel.FilmsCountriesList != null)
                    foreach (var country in filmViewModel.FilmsCountriesList)
                    {
                        var nameCountry = _context.Countries.FirstOrDefault(x => x.Name == country.Name);
                
                        if (nameCountry == null)
                        {
                            _countryRepository.Create(new Country {Name = country.Name});
                            nameCountry = _countryRepository.GetByName(country.Name);
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
                
                if (filmViewModel.FilmsGenreList != null)
                    foreach (var genre in filmViewModel.FilmsGenreList)
                    {
                        var nameGenre = _context.Genres.FirstOrDefault(x => x.Name == genre.Name);
                
                        if (nameGenre == null)
                        {
                            _genreRepository.Create(new Genre {Name = genre.Name});
                            nameGenre = _genreRepository.GetByName(genre.Name);
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
                
                if (filmViewModel.ActorsList != null)
                    foreach (var name in filmViewModel.ActorsList)
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
                
                        var filmsActors = new Character()
                        {
                            FilmId = film.Id,
                            ActorId = idActors,
                            Role = name.Role
                        };
                        _context.Characters.Add(filmsActors);
                        _context.SaveChanges();
                    }
                
                if (filmViewModel.TopActorsList != null)
                    foreach (var name in filmViewModel.TopActorsList)
                    {
                        var nameActor =
                            _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == name.ActorKinopoiskId);
                
                        var idActors = nameActor.Id;
                
                        var filmsActors = new TopActor()
                        {
                            FilmId = film.Id,
                            ActorId = idActors,
                        };
                        _context.TopActors.Add(filmsActors);
                        _context.SaveChanges();
                    }
                
                if (filmViewModel.WritersList != null)
                    foreach (var name in filmViewModel.WritersList)
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
                
                        var filmsWriter = new Writers()
                        {
                            FilmId = film.Id,
                            WriterId = idWriter,
                        };
                        _context.Writers.Add(filmsWriter);
                        _context.SaveChanges();
                    }
                
                if (filmViewModel.DirectorList != null)
                    foreach (var name in filmViewModel.DirectorList)
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
                
                        var filmsDirector = new Director()
                        {
                            FilmId = film.Id,
                            DirectorId = idWriter,
                        };
                        _context.Directors.Add(filmsDirector);
                        _context.SaveChanges();
                    }
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

            if (film.Result == null)
            {
                CreateFilm(filmViewModels);
                return baseResponce;
            }

            film.Result.Title = filmViewModels.Title;
            film.Result.Poster = filmViewModels.Poster;
            film.Result.Year = filmViewModels.Year;
            film.Result.LinkVideo = filmViewModels.LinkVideo;
            film.Result.Duration = filmViewModels.Duration;
            film.Result.Plot = filmViewModels.Plot;
            film.Result.KinopoiskRating = filmViewModels.KinopoiskRating;
            film.Result.YoutubeTrailer = filmViewModels.YoutubeTrailer;
            film.Result.ThumbnailUrl = filmViewModels.ThumbnailUrl;
            _filmRepository.Update(film.Result);

            var filmCountry = _context.FilmsCountriesEnumerable.Where(x => x.FilmsId == id);

            foreach (var fc in filmCountry)
            {
                _context.FilmsCountriesEnumerable.Remove(fc);
            }

            _context.SaveChanges();

            if (filmViewModels.FilmsCountriesList != null)
                foreach (var name in filmViewModels.FilmsCountriesList)
                {
                    var nameCountry = _countryRepository.GetByName(name.Name);

                    if (nameCountry == null)
                    {
                        _countryRepository.Create(new Country {Name = name.Name});
                        nameCountry = _countryRepository.GetByName(name.Name);
                    }

                    var idCountry = nameCountry.Id;

                    var filmsCountries = new FilmsCountries()
                    {
                        FilmsId = id,
                        CountryId = idCountry,
                    };
                    _context.FilmsCountriesEnumerable.Add(filmsCountries);
                    _context.SaveChanges();
                }

            var filmGenre = _context.FilmsGenresEnumerable.Where(x => x.FilmsId == id);

            foreach (var fg in filmGenre)
            {
                _context.FilmsGenresEnumerable.Remove(fg);
            }

            _context.SaveChanges();

            if (filmViewModels.FilmsGenreList != null)
                foreach (var name in filmViewModels.FilmsGenreList)
                {
                    var nameGenre = _genreRepository.GetByName(name.Name);

                    if (nameGenre == null)
                    {
                        _genreRepository.Create(new Genre {Name = name.Name});
                        nameGenre = _genreRepository.GetByName(name.Name);
                    }

                    var idCountry = nameGenre.Id;

                    var filmsGenres = new FilmsGenres()
                    {
                        FilmsId = id,
                        GenreId = idCountry,
                    };
                    _context.FilmsGenresEnumerable.Add(filmsGenres);
                    _context.SaveChanges();
                }


            var filmActor = _context.Characters.Where(x => x.FilmId == id);

            foreach (var fa in filmActor)
            {
                _context.Characters.Remove(fa);
            }

            _context.SaveChanges();

            if (filmViewModels.ActorsList != null)
                foreach (var name in filmViewModels.ActorsList)
                {
                    var nameActor = _context.Persons.FirstOrDefault(x => x.Id == name.Id);

                    if (nameActor == null)
                    {
                        _actorRepository.Create(new Person() {Name = name.Name});
                        nameActor = _context.Persons.FirstOrDefault(x => x.Id == name.Id);
                    }

                    var idActors = nameActor.Id;

                    var filmsActors = new Character()
                    {
                        FilmId = id,
                        ActorId = idActors,
                        Role = name.Role
                    };
                    _context.Characters.Add(filmsActors);
                    _context.SaveChanges();
                }


            var filmTopActor = _context.TopActors.Where(x => x.FilmId == id);

            foreach (var fta in filmTopActor)
            {
                _context.TopActors.Remove(fta);
            }

            _context.SaveChanges();

            foreach (var name in filmViewModels.TopActorsList)
            {
                var nameActor = _context.Persons.FirstOrDefault(x => x.Id == name.Id);

                var idActors = nameActor.Id;

                var filmsActors = new TopActor()
                {
                    FilmId = id,
                    ActorId = idActors,
                };
                _context.TopActors.Add(filmsActors);
                _context.SaveChanges();
            }

            var filmWriter = _context.Writers.Where(x => x.FilmId == id);

            foreach (var fw in filmWriter)
            {
                _context.Writers.Remove(fw);
            }

            _context.SaveChanges();

            foreach (var name in filmViewModels.WritersList)
            {
                var nameWriter = _context.Persons.FirstOrDefault(x => x.Id == name.Id);

                if (nameWriter == null)
                {
                    _actorRepository.Create(new Person() {Name = name.Name});
                    nameWriter = _context.Persons.FirstOrDefault(x => x.Id == name.Id);
                }

                var idWriter = nameWriter.Id;

                var filmsWriter = new Writers()
                {
                    FilmId = id,
                    WriterId = idWriter,
                };
                _context.Writers.Add(filmsWriter);
                _context.SaveChanges();
            }

            var filmDirector = _context.Directors.Where(x => x.FilmId == id);

            foreach (var fd in filmDirector)
            {
                _context.Directors.Remove(fd);
            }

            _context.SaveChanges();

            foreach (var name in filmViewModels.DirectorList)
            {
                var nameDirector = _context.Persons.FirstOrDefault(x => x.Id == name.Id);

                if (nameDirector == null)
                {
                    _actorRepository.Create(new Person() {Name = name.Name});
                    nameDirector = _context.Persons.FirstOrDefault(x => x.Id == name.Id);
                }

                var idDirector = nameDirector.Id;

                var filmsDirector = new Director()
                {
                    FilmId = id,
                    DirectorId = idDirector,
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