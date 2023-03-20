using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Data.Filters;
using KodalibApi.Interfaces.Base;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Response;
using KodalibApi.Data.ViewModels.CreateViewModels;
using KodalibApi.Data.ViewModels.Film;

namespace Kodalib.Service.Interfaces;

public interface IFilmService
{
    // Getting all movies
    Task<IBaseResponse> GetFilms(PageParameters pageParameters, FilmsFilters filmsFilters, CancellationToken cancellationToken);
    Task<IBaseResponse> GetFilmById(int id, CancellationToken cancellationToken);
    Task<IBaseResponse> CreateFilm(CreateFilmViewModel film, CancellationToken cancellationToken);
    Task CreateFilms(List<CreateFilmViewModel> film, CancellationToken cancellationToken);
}