using KodalibApi.Interfaces.FilmIntefaces;
using Kodalib.Repository;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.DataInfill.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFilmService _filmService;
    private readonly IFilmDataInfill _dataInfill;

    public FilmsController(IFilmService filmService, IFilmDataInfill dataInfill)
    {
        _filmService = filmService;
        _dataInfill = dataInfill;
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

    [HttpPut("UpdateFilm", Name = "UpdateFilm")]
    public void UpdateFilm(int id, FilmViewModels filmViewModels)
    {
        _filmService.UpdateFilm(id, filmViewModels);
    }
    
    [HttpPost("createNewFilmWithApi", Name = "createNewFilmWithApi")]
    public void CreateWithApi([FromBody]List<string> id)
    {
        _dataInfill.Create(id);
    }
}