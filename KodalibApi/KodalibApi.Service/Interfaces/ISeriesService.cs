using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Data.Filters;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.Response;
using KodalibApi.Data.ViewModels.CreateViewModels;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Series;

namespace Kodalib.Service.Interfaces;

public interface ISeriesService
{
    Task<IBaseResponse> GetSeries(PageParameters pageParameters, FilmsFilters filmsFilters, CancellationToken cancellationToken);
    Task<IBaseResponse> GetLastSeries( CancellationToken cancellationToken);
    Task<IBaseResponse> GetSeriesById(int id, CancellationToken cancellationToken);
    Task<IBaseResponse> CreateSeries(List<CreateSeriesViewModel> series, CancellationToken cancellationToken);
    Task<IBaseResponse> GetLastEpisodes(CancellationToken cancellationToken);
}