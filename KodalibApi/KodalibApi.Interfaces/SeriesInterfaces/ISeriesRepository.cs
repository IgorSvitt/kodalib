using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.ViewModels.Series;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces;

public interface ISeriesRepository: IBaseRepository<Series>
{
    Task<SeriesViewModel> GetByIdFullDescription(int id);

    Task<List<SeriesViewModel>> GetAllSeries();
    
    Task<SeriesViewModel> GetByTitleFullDescription(string title);
}