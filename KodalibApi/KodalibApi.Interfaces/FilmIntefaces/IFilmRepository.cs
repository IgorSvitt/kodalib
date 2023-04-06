using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Data.Filters;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.CreateViewModels;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.FilmIntefaces;

public interface IFilmRepository: IBaseRepository<Film>
{
    Task<PagedList<FilmViewModels>> GetFilms(PageParameters pageParameters, FilmsFilters filmsFilters, CancellationToken cancellationToken);
    Task<List<FilmViewModels>> GetLastFilms( CancellationToken cancellationToken);
    
    Task<FilmViewModels?> GetFilmById(int id, CancellationToken cancellationToken);
    
    Task<IdViewModel> CreateFilm(FilmViewModels film, CancellationToken cancellationToken);
}
