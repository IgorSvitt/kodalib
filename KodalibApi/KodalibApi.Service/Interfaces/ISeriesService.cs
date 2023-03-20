using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.Response;
using KodalibApi.Data.ViewModels.CreateViewModels;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Series;

namespace Kodalib.Service.Interfaces;

public interface ISeriesService
{
    Task<IBaseResponse> GetSeries(PageParameters pageParameters, CancellationToken cancellationToken);
    Task<IBaseResponse> GetSeriesById(int id, CancellationToken cancellationToken);
    Task<IBaseResponse> CreateSeries(List<CreateSeriesViewModel> series, CancellationToken cancellationToken);
}