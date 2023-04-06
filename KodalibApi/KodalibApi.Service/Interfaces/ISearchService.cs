using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Data.Filters;
using KodalibApi.Data.Response;

namespace Kodalib.Service.Interfaces;

public interface ISearchService
{
    Task<IBaseResponse> GetSearch(FilmsFilters filmsFilters, PageParameters pageParameters, CancellationToken cancellationToken);
}