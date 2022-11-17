using Kodalib.Interfaces.Base;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Film;

namespace Kodalib.Interfaces.FilmIntefaces;

public interface IFilmRepository: IBaseRepository<Film>
{
    Task<FilmViewModels> GetById(int id);

    Task<List<FilmViewModels>> GetAllFilms();
    
    Task<Film> GetByTitle(string id);
    
}