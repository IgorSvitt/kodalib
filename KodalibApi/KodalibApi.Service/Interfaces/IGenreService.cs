using KodalibApi.Data.Models;
using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Genre;
using KodalibApi.Interfaces.Base;

namespace Kodalib.Service.Interfaces;

public interface IGenreService
{
    IBaseResponce<IEnumerable<GenreViewModel>> GetGenres();

    IBaseResponce<GenreViewModel> GetGenre(int id);
    
    IBaseResponce<GenreViewModel> GetGenreByName(string name);

    IBaseResponce<bool> DeleteGenre(int id);

    IBaseResponce<GenreViewModel> CreateGenre(string countryViewModelName);

    IBaseResponce<GenreViewModel> UpdateGenre(int id, GenreViewModel genreViewModel);
}