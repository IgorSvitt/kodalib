using Kodalib.Interfaces.GenreInterfaces;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Genre;

namespace Kodalib.Service.Implementations;

public class GenreService: IGenreService
{

    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    
    public IBaseResponce<IEnumerable<GenreViewModel>> GetGenres()
    {
        var baseResponce = new BaseResponce<IEnumerable<GenreViewModel>>();

        try
        {
            var genres = _genreRepository.GetAllGenres();
            if (genres.Result.Count == 0)
            {
                baseResponce.Description = "Genre 0 elements";
                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }

            baseResponce.Data = genres.Result;
            baseResponce.StatusCode = StatusCode.OK;


            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<IEnumerable<GenreViewModel>>()
            {
                Description = $"[GetGenre] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<GenreViewModel> GetGenre(int id)
    {
        var baseResponce = new BaseResponce<GenreViewModel>();

        try
        {
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                baseResponce.Description = "Genre not found";
                baseResponce.StatusCode = StatusCode.GenreNotFound;
                return baseResponce;
            }

            baseResponce.Data = genre.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<GenreViewModel>()
            {
                Description = $"[GetGenre] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<Genre> GetGenreByName(string name)
    {
        var baseResponce = new BaseResponce<Genre>();

        try
        {
            var genre = _genreRepository.GetByName(name);
            if (genre == null)
            {
                baseResponce.Description = "Genre not found";
                baseResponce.StatusCode = StatusCode.GenreNotFound;
                return baseResponce;
            }

            baseResponce.Data = genre.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<Genre>()
            {
                Description = $"[GetGenre] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<bool> DeleteGenre(int id)
    {
        var baseResponse = new BaseResponce<bool>();

        try
        {
            var genre = _genreRepository.Get(id);
            if (genre == null)
            {
                baseResponse.Description = "Genre not found";
                baseResponse.StatusCode = StatusCode.CountryNotFound;
                baseResponse.Data = false;
                return baseResponse;
            }

            _genreRepository.Delete(genre.Result);
            baseResponse.Data = true;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponce<bool>()
            {
                Description = $"[GetGenre] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public IBaseResponce<GenreViewModel> CreateGenre(GenreViewModel genreViewModel)
    {
        var baseResponce = new BaseResponce<GenreViewModel>();

        try
        {
            var genreName = _genreRepository.GetByName(genreViewModel.Name);

            if (genreName != null)
            {
                baseResponce.StatusCode = StatusCode.InternalServerError;
                return baseResponce;
            }
            var genre = new Genre()
            {
                Name = genreViewModel.Name,
            };
            _genreRepository.Create(genre);
        }
        catch (Exception ex)
        {
            return new BaseResponce<GenreViewModel>()
            {
                Description = $"[GetCountry] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }
}