using Kodalib.Interfaces.FilmIntefaces;
using Kodalib.Repository;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Film;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFilmService _filmService;

    public FilmsController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    [HttpGet("GetFilms",Name = "GetFilms")]
    public IEnumerable<FilmViewModels> GetFilms()
    {
       var responce = _filmService.GetFilms();
       return responce.Data;
    }

    [HttpGet("GetFilm/{id}",Name = "GetFilm")]
    public FilmViewModels GetFilm(int id)
    {
        var responce = _filmService.GetFilm(id);

        return responce.Data;
    }

    [HttpDelete("DeleteFilm", Name = "DeleteFilm")]
    public void DeleteFilm(int id)
    {
        _filmService.DeleteFilms(id);
    }

    [HttpPost("CreateFilm", Name = "CreateFilm")]
    public void CreateFilm(FilmViewModels filmViewModels)
    {
        _filmService.CreateFilm(filmViewModels);
    }
}