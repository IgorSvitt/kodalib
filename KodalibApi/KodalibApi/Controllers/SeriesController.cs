using GenelogyApi.Domain.ViewModels.Pages;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Filters;
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
    public async Task<IBaseResponse> GetSeries([FromQuery] PageParameters pageParameters,  [FromQuery] FilmsFilters filmsFilters)
    {
        var response = await _seriesService.GetSeries(pageParameters, filmsFilters, HttpContext.RequestAborted);
        return response;
    }
    
    [HttpGet("last", Name = "GetLastSeries")]
    public async Task<IBaseResponse> GetLastSeries()
    {
        var response = await _seriesService.GetLastSeries(HttpContext.RequestAborted);
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
    
    [HttpGet("last-episodes", Name = "LastEpisodes")]
    public async Task<IBaseResponse> LastEpisodes()
    {
        var response = await _seriesService.GetLastEpisodes(HttpContext.RequestAborted);
        return response;
    }
}