using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.CreateViewModels;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.CountryInterfaces;

public interface ICountryRepository: IBaseRepository<Country>
{
    Task<List<CountryViewModel>> GetCountries(CancellationToken cancellationToken);

    Task<CountryViewModel?> GetCountryByName(string country,CancellationToken cancellationToken);
    Task<IdViewModel?> GetCountryIdByName(string country,CancellationToken cancellationToken);

    Task<IdViewModel> CreateCountry(string country, CancellationToken cancellationToken);
}