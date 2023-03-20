using KodalibApi.Interfaces.Base;
using KodalibApi.Data.Models;
using KodalibApi.Data.Response;
using KodalibApi.Data.ViewModels.Country;

namespace Kodalib.Service.Interfaces;

public interface ICountryService
{
    Task<IBaseResponse> GetCountries(CancellationToken cancellationToken);
}