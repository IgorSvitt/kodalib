using Kodalib.Service.Interfaces;
using KodalibApi.Data.ViewModels.Series;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SerialController : ControllerBase
{
    private readonly ISeriesService _seriesService;

    public SerialController(ISeriesService seriesService)
    {
        _seriesService = seriesService;
    }
    
    [HttpGet("GetSeries", Name = "GetSeries")]
    public IEnumerable<SeriesViewModel> GetSeries()
    {
        var responce = _seriesService.GetSeries();
        return responce.Data;
    }

    [HttpGet("GetOneSeries/{id}", Name = "GetOneSeries")]
    public  IActionResult GetOneSeries(int id)
    {
        var responce = _seriesService.GetOneSeries(id);
        if (responce.StatusCode == Data.Responce.Enum.StatusCode.OK)
        {
            return  Ok(responce.Data);
        }
        return  NotFound();
    }

    [HttpDelete("DeleteSeries", Name = "DeleteSeries")]
    public void DeleteSeries(int id)
    {
        _seriesService.DeleteSeries(id);
    }

    [HttpPut("UpdateSeries", Name = "UpdateSeries")]
    public void UpdateSeries(int id, SeriesViewModel seriesViewModel)
    {
        _seriesService.UpdateSeries(id, seriesViewModel);
    }


    // Create methods

    [HttpPost("CreateOneSeries", Name = "CreateOneSeries")]
    public void CreateOneSeries(SeriesViewModel seriesViewModel)
    {
        _seriesService.CreateOneSeries(seriesViewModel);
    }
    
    [HttpPost("CreateSeries", Name = "CreateSeries")]
    public void CreateSeries(List<SeriesViewModel> seriesViewModel)
    {
        _seriesService.CreateSeries(seriesViewModel);
    }
}