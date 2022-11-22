using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.FilmIntefaces;

public interface IFilmRepository: IBaseRepository<Film>
{
    Task<FilmViewModels> GetByIdFullDescription(int id);

    Task<List<FilmViewModels>> GetAllFilms();
    
    Task<FilmViewModels> GetByTitleFullDescription(string id);
    
}