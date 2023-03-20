using GenelogyApi.Domain.ViewModels.Pages;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Response;
using KodalibApi.Data.ViewModels.CreateViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/series")]
[Produces("application/json")]
[Consumes("application/json")]
public class SeriesController : ControllerBase
{
    private readonly ISeriesService _seriesService;

    public SeriesController(ISeriesService seriesService)
    {
        _seriesService = seriesService;
    }
    
    [HttpGet(Name = "GetSeries")]
    public async Task<IBaseResponse> GetSeries([FromQuery] PageParameters pageParameters)
    {
        var response = await _seriesService.GetSeries(pageParameters, HttpContext.RequestAborted);
        return response;
    }
    
    [HttpGet("{id}",Name = "GetSeriesById")]
    public async Task<IBaseResponse> GetSeriesById(int id)
    {
        var response = await _seriesService.GetSeriesById(id, HttpContext.RequestAborted);
        return response;
    }
    
    [HttpPost("series",Name = "CreateSeries")]
    public async Task CreateFilms(List<CreateSeriesViewModel> series)
    {
        await _seriesService.CreateSeries(series, HttpContext.RequestAborted);
    }
}