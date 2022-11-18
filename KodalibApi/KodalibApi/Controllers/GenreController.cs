using Kodalib.Interfaces.GenreInterfaces;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Genre;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;


[ApiController]
[Route(("api/[controller]"))]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }
    
    [HttpGet("GetGenres")]
    public IEnumerable<GenreViewModel> GetCountries()
    {
        var responce = _genreService.GetGenres();
        return responce.Data;
    }
    
    [HttpGet("GetGenre/{id}")]
    public GenreViewModel GetCountry(int id)
    {
        var responce = _genreService.GetGenre(id);
        return responce.Data;
    }
    
    [HttpGet("GetGenreByName/{name}")]
    public Genre GetCountryByName(string name)
    {
        var responce = _genreService.GetGenreByName(name);
        return responce.Data;
    }

    [HttpPost("CreateGenre")]
    public void CreateCountry(GenreViewModel countryViewModel)
    {
        _genreService.CreateGenre(countryViewModel);
    }

    [HttpDelete("DeleteGenre")]
    public void DeleteCountry(int id)
    {
        _genreService.DeleteGenre(id);
    }
}