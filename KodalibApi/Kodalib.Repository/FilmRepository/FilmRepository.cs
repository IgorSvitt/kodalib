using Kodalib.Interfaces.FilmIntefaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Film;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.FilmRepository;

public class FilmRepository: IFilmRepository
{
    private readonly ApplicationDbContext _context;

    public FilmRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(Film entity)
    {
        _context.Films.Add(entity);
        Save();
    }

    public async Task<List<Film>> Select()
    {
        return await _context.Films.ToListAsync();
    }
    public async Task<Film> Get(int id)
    {
        return await _context.Films.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<FilmViewModels> GetById(int id)
    {
        return await _context.Films.Where(n=> n.Id == id).Select(film => new FilmViewModels()
        {
            Id = film.Id,
            ImdbId = film.ImdbId,
            Title = film.Title,
            Poster = film.Poster,
            Year = film.Year,
            Duration = film.Duration,
            Plot = film.Plot,
            ImdbRating =film.ImdbRating,
            Budget = film.Budget,
            GrossWorldwide = film.GrossWorldwide,
            YoutubeTrailer = film.YoutubeTrailer,
            FilmsCountriesList = film.CountriesList.Select(n=> n.Country.Name).ToList()
        }).FirstOrDefaultAsync();
    }
    
    public async Task<List<FilmViewModels>> GetAllFilms()
    {
        return await _context.Films.Select(film => new FilmViewModels()
        {
            Id = film.Id,
            ImdbId = film.ImdbId,
            Title = film.Title,
            Poster = film.Poster,
            Year = film.Year,
            Duration = film.Duration,
            Plot = film.Plot,
            ImdbRating = film.ImdbRating,
            Budget = film.Budget,
            GrossWorldwide = film.GrossWorldwide,
            YoutubeTrailer = film.YoutubeTrailer,
            FilmsCountriesList = film.CountriesList.Select(n => n.Country.Name).ToList()
        }).ToListAsync();
    }

    public void Delete(Film entity)
    {
        _context.Films.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task<Film> GetByTitle(string title)
    {
        return await _context.Films.FirstOrDefaultAsync(x => x.Title == title);
    }
}