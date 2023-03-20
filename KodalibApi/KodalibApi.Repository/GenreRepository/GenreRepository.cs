using KodalibApi.Dal.Context;
using KodalibApi.Interfaces.GenreInterfaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels;
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

    public void Delete(Genre entity)
    {
        _context.Genres.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Genre entity)
    {
        _context.Genres.Update(entity);
    }

    public async Task<List<GenreViewModel>> GetGenres(CancellationToken cancellationToken)
    {
        return await _context.Genres
            .Select(g => new GenreViewModel()
            {
                Id = g.Id,
                Name = g.Name
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<GenreViewModel?> GetGenreByName(string genre, CancellationToken cancellationToken)
    {
        
        return await _context.Genres
            .Where(x => x.Name.ToLower() == genre.ToLower())
            .Select(c => new GenreViewModel()
            {
                Id = c.Id,
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel?> GetGenreIdByName(string genre, CancellationToken cancellationToken)
    {
        return await _context.Genres
            .Where(x => x.Name.ToLower() == genre.ToLower())
            .Select(c => new IdViewModel()
            {
                Id = c.Id,
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel> CreateGenre(string genre, CancellationToken cancellationToken)
    {
        var data = new Genre()
        {
            Name = genre,
        };
        
        await _context.Genres.AddAsync(data, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new IdViewModel() {Id = data.Id};
    }
}