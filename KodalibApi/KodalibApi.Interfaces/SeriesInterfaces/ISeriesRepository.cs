using GenelogyApi.Domain.ViewModels.Pages;
using KodalibApi.Data.Filters;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Series;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces;

public interface ISeriesRepository: IBaseRepository<Series>
{
    Task<PagedList<SeriesViewModel>> GetSeries(PageParameters pageParameters, FilmsFilters filmsFilters, CancellationToken cancellationToken);
    Task<List<SeriesViewModel>> GetLastSeries(CancellationToken cancellationToken);
    Task<SeriesViewModel?> GetSeriesById(int id, CancellationToken cancellationToken);
    Task<List<EpisodeViewModel?>> GetLastEpisodes(CancellationToken cancellationToken);
    Task<IdViewModel> CreateSeries(SeriesViewModel series, CancellationToken cancellationToken);
}