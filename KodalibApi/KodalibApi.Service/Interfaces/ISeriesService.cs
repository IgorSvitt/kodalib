using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.SeriesTable;
using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Series;

namespace Kodalib.Service.Interfaces;

public interface ISeriesService
{
    // Getting all movies
    IBaseResponce<IEnumerable<SeriesViewModel>> GetSeries();

    // Getting a movie by id
    IBaseResponce<SeriesViewModel> GetOneSeries(int id);
    
    // Getting a movie by title
    IBaseResponce<Series> GetSeriesByName(string name);
    
    // Delete a movie 
    IBaseResponce<bool> DeleteSeries(int id);

    // Create a movie

    IBaseResponce<SeriesViewModel> CreateOneSeries(SeriesViewModel seriesViewModel);
    
    IBaseResponce<SeriesViewModel> CreateSeries(List<SeriesViewModel> seriesViewModel);
    

    IBaseResponce<SeriesViewModel> UpdateSeries(int id, SeriesViewModel seriesViewModel);
}