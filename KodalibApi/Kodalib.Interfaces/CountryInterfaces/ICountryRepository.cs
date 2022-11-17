using Kodalib.Interfaces.Base;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Country;

namespace Kodalib.Interfaces.CountryInterfaces;

public interface ICountryRepository: IBaseRepository<Country>
{
    public Task<Country> GetByName(string name);

    public Task<CountryViewModel> GetById(int id);

    public Task<List<CountryViewModel>> GetAllCountry();
}