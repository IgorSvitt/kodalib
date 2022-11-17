using Kodalib.Interfaces.CountryInterfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Country;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.CountryRepository;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _context;

    public CountryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(Country entity)
    {
        _context.Countries.Add(entity);
        Save();
    }

    public async Task<Country> Get(int id)
    {
        return await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Country>> Select()
    {
        return await _context.Countries.ToListAsync();
    }

    public void Delete(Country entity)
    {
        _context.Countries.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task<Country> GetByName(string name)
    {
        return _context.Countries.FirstOrDefault(x => x.Name == name);
    }

    public async Task<CountryViewModel> GetById(int id)
    {
        return await _context.Countries.Where(x => x.Id == id).Select(country => new CountryViewModel()
        {
            Name = country.Name,
            FilmTitle = country.FilmsList.Select(n => n.Film.Title).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<List<CountryViewModel>> GetAllCountry()
    {
        return await _context.Countries.Select(country => new CountryViewModel()
        {
            Name = country.Name,
            FilmTitle = country.FilmsList.Select(n => n.Film.Title).ToList()
        }).ToListAsync();
    }
}