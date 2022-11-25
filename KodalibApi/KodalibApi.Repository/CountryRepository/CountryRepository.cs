using KodalibApi.Interfaces.CountryInterfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Film;
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

    public async Task<Country> GetById(int id)
    {
        return await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Country GetByName(string name)
    {
        return  _context.Countries.FirstOrDefault(x => x.Name == name);
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

    public void Update(Country entity)
    {
        _context.Countries.Update(entity);
        Save();
    }

    public async Task<CountryViewModel> GetByNameFullDescription(string name)
    {
        var countryViewModel = _context.Countries.Where(x => x.Name == name).Select(country => new CountryViewModel()
        {
            Id = country.Id,
            Name = country.Name,
            FilmTitle = country.FilmsList.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmsId,
                Title = film.Film.Title,
            }).ToList()
        }).FirstOrDefaultAsync();
        
        return await countryViewModel;

    }

    public async Task<CountryViewModel> GetByIdFullDescription(int id)
    {
        return await _context.Countries.Where(x => x.Id == id).Select(country => new CountryViewModel()
        {
            Id = country.Id,
            Name = country.Name,
            FilmTitle = country.FilmsList.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmsId,
                Title = film.Film.Title,
            }).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<List<CountryViewModel>> GetAllCountry()
    {
        return await _context.Countries.Select(country => new CountryViewModel()
        {
            Id = country.Id,
            Name = country.Name,
            FilmTitle = country.FilmsList.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmsId,
                Title = film.Film.Title,
            }).ToList()
        }).ToListAsync();
    }
}