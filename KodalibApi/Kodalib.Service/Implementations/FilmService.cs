using Kodalib.Interfaces.Base;
using Kodalib.Interfaces.CountryInterfaces;
using Kodalib.Interfaces.FilmIntefaces;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Film;

namespace Kodalib.Service.Implementations;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;
    private readonly ApplicationDbContext _context;
    private readonly ICountryRepository _countryRepository;


    public FilmService(IFilmRepository filmRepository, ApplicationDbContext context, ICountryRepository countryRepository)
    {
        _filmRepository = filmRepository;
        _context = context;
        _countryRepository = countryRepository;
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
            var film = _filmRepository.GetById(id);
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
            var film = _filmRepository.Get(id);
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
                var nameCountry = _context.Countries.FirstOrDefault(x => x.Name == name);

                if (nameCountry == null)
                {
                    _countryRepository.Create(new Country{Name = name});
                    nameCountry = _context.Countries.FirstOrDefault(x => x.Name == name);
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
}