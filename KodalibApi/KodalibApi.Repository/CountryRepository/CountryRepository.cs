using KodalibApi.Dal.Context;
using KodalibApi.Interfaces.CountryInterfaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.CreateViewModels;
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

    public async Task<List<CountryViewModel>> GetCountries(CancellationToken cancellationToken)
    {
        return await _context.Countries
            .Select(c => new CountryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<CountryViewModel?> GetCountryByName(string country, CancellationToken cancellationToken)
    {
        return await _context.Countries
            .Where(x => x.Name.ToLower() == country.ToLower())
            .Select(c => new CountryViewModel()
            {
                Id = c.Id,
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel?> GetCountryIdByName(string country, CancellationToken cancellationToken)
    {
        return await _context.Countries
            .Where(x => x.Name.ToLower() == country.ToLower())
            .Select(c => new IdViewModel()
            {
                Id = c.Id
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel> CreateCountry(string country, CancellationToken cancellationToken)
    {
        var data = new Country()
        {
            Name = country,
        };
        
        await _context.Countries.AddAsync(data, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new IdViewModel() {Id = data.Id};
    }
}