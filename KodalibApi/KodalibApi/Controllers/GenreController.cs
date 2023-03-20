using Kodalib.Service.Interfaces;
using KodalibApi.Data.Response;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;


[ApiController]
[Route(("api/genres"))]
[Produces("application/json")]
[Consumes("application/json")] 
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }
    
    [HttpGet(Name = "GetGenres")]
    public async Task<IBaseResponse> GetGenres()
    {
        var response = await _genreService.GetGenres(HttpContext.RequestAborted);
        return response;
    }
}