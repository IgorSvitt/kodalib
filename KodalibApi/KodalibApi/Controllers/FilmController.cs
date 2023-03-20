using GenelogyApi.Domain.ViewModels.Pages;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Filters;
using KodalibApi.Data.Response;
using KodalibApi.Data.ViewModels.CreateViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/films")]
[Produces("application/json")]
[Consumes("application/json")] 
public class FilmController : ControllerBase
{
    private readonly IFilmService _filmService;

    public FilmController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    [HttpGet(Name = "GetFilms")]
    public async Task<IBaseResponse> GetFilms([FromQuery] PageParameters pageParameters, [FromQuery] FilmsFilters filmsFilters)
    {
        var response = await _filmService.GetFilms(pageParameters, filmsFilters, HttpContext.RequestAborted);
        return response;
    }
    
    [HttpGet("{id}",Name = "GetFilmsById")]
    public async Task<IBaseResponse> GetFilmsById(int id)
    {
        var response = await _filmService.GetFilmById(id, HttpContext.RequestAborted);
        return response;
    }

    [HttpPost(Name = "CreateFilm")]
    public async Task<IBaseResponse> CreateFilm(CreateFilmViewModel film)
    {
        var response = await _filmService.CreateFilm(film, HttpContext.RequestAborted);
        return response;
    }
    
    [HttpPost("films",Name = "CreateFilms")]
    public async Task CreateFilms(List<CreateFilmViewModel> films)
    {
        await _filmService.CreateFilms(films, HttpContext.RequestAborted);
    }
}