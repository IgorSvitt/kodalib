using KodalibApi.Interfaces.GenreInterfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Genre;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.GenreRepository;

public class GenreRepository: IGenreRepository
{
    private readonly ApplicationDbContext _context;

    public GenreRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Genre entity)
    {
        _context.Genres.Add(entity);
        Save();
    }

    public async Task<Genre> GetById(int id)
    {
        return await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Genre GetByName(string name)
    {
        return  _context.Genres.FirstOrDefault(x => x.Name == name);
    }

    public async Task<List<Genre>> Select()
    {
        return await _context.Genres.ToListAsync();
    }

    public void Delete(Genre entity)
    {
        _context.Genres.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task<GenreViewModel> GetByNameFullDescription(string name)
    {
        return await _context.Genres.Where(x => x.Name == name).Select(genre => new GenreViewModel()
        {
            Id = genre.Id,
            Name = genre.Name,
            FilmTitle = genre.FilmsList.Select(n => n.Film.Title).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<GenreViewModel> GetByIdFullDescription(int id)
    {
        return await _context.Genres.Where(x => x.Id == id).Select(genre => new GenreViewModel()
        {
            Id = genre.Id,
            Name = genre.Name,
            FilmTitle = genre.FilmsList.Select(n => n.Film.Title).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<List<GenreViewModel>> GetAllGenres()
    {
        return await _context.Genres.Select(genre => new GenreViewModel()
        {
            Id = genre.Id,
            Name = genre.Name,
            FilmTitle = genre.FilmsList.Select(n => n.Film.Title).ToList()
        }).ToListAsync();
    }
}