using KodalibApi.Interfaces.FilmIntefaces;
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

    [HttpGet("GetFilms", Name = "GetFilms")]
    public IEnumerable<FilmViewModels> GetFilms()
    {
        var responce = _filmService.GetFilms();
        return responce.Data;
    }

    [HttpGet("GetFilm/{id}", Name = "GetFilm")]
    public  IActionResult GetFilm(int id)
    {
        var responce = _filmService.GetFilm(id);
        if (responce.StatusCode == Data.Responce.Enum.StatusCode.OK)
        {
            return  Ok(responce.Data);
        }
        return  NotFound();
    }

    [HttpDelete("DeleteFilm", Name = "DeleteFilm")]
    public void DeleteFilm(int id)
    {
        _filmService.DeleteFilms(id);
    }

    [HttpPut("UpdateFilm", Name = "UpdateFilm")]
    public void UpdateFilm(int id, FilmViewModels filmViewModels)
    {
        _filmService.UpdateFilm(id, filmViewModels);
    }


    // Create methods

    [HttpPost("CreateFilm", Name = "CreateFilm")]
    public void CreateFilm(FilmViewModels filmViewModels)
    {
        _filmService.CreateFilm(filmViewModels);
    }
    
    [HttpPost("CreateFilms", Name = "CreateFilms")]
    public void CreateFilms(List<FilmViewModels> filmViewModels)
    {
        _filmService.CreateFilms(filmViewModels);
    }


}