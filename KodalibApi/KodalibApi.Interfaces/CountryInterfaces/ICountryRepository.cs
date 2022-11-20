using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.CountryInterfaces;

public interface ICountryRepository: IBaseRepository<Country>
{
    public Task<CountryViewModel> GetByNameFullDescription(string name);

    public Task<CountryViewModel> GetByIdFullDescription(int id);

    public Task<List<CountryViewModel>> GetAllCountry();
}