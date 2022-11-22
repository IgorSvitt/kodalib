using KodalibApi.Interfaces.Base;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Film;

namespace Kodalib.Service.Interfaces;

public interface IFilmService
{
    // Getting all movies
    IBaseResponce<IEnumerable<FilmViewModels>> GetFilms();

    // Getting a movie by id
    IBaseResponce<FilmViewModels> GetFilm(int id);
    
    // Getting a movie by title
    IBaseResponce<Film> GetFilmByName(string name);
    
    // Delete a movie 
    IBaseResponce<bool> DeleteFilms(int id);

    // Create a movie
    IBaseResponce<Film> CreateFilm(FilmViewModels filmViewModels);
}