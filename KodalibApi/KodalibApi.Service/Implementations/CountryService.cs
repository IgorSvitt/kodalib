using KodalibApi.Interfaces.CountryInterfaces;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.Country;

namespace Kodalib.Service.Implementations;

public class CountryService: ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    
    public IBaseResponce<IEnumerable<CountryViewModel>> GetCountries()
    {
        var baseResponce = new BaseResponce<IEnumerable<CountryViewModel>>();

        try
        {
            var countries = _countryRepository.GetAllCountry();
            if (countries.Result.Count == 0)
            {
                baseResponce.Description = "Found 0 elements";
                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }

            baseResponce.Data = countries.Result;
            baseResponce.StatusCode = StatusCode.OK;


            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<IEnumerable<CountryViewModel>>()
            {
                Description = $"[GetCountries] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<CountryViewModel> GetCountry(int id)
    {
        var baseResponce = new BaseResponce<CountryViewModel>();

        try
        {
            var country = _countryRepository.GetByIdFullDescription(id);
            if (country == null)
            {
                baseResponce.Description = "Country not found";
                baseResponce.StatusCode = StatusCode.CountryNotFound;
                return baseResponce;
            }

            baseResponce.Data = country.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<CountryViewModel>()
            {
                Description = $"[GetCountry] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<CountryViewModel> GetCountryByName(string name)
    {
        var baseResponce = new BaseResponce<CountryViewModel>();

        try
        {
            var country = _countryRepository.GetByNameFullDescription(name);
            if (country == null)
            {
                baseResponce.Description = "Country not found";
                baseResponce.StatusCode = StatusCode.CountryNotFound;
                return baseResponce;
            }

            baseResponce.Data = country.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<CountryViewModel>()
            {
                Description = $"[GetCountry] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<bool> DeleteCountry(int id)
    {
        var baseResponse = new BaseResponce<bool>();

        try
        {
            var country = _countryRepository.GetById(id);
            if (country == null)
            {
                baseResponse.Description = "Country not found";
                baseResponse.StatusCode = StatusCode.CountryNotFound;
                baseResponse.Data = false;
                return baseResponse;
            }

            _countryRepository.Delete(country.Result);
            baseResponse.Data = true;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponce<bool>()
            {
                Description = $"[GetCountry] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public IBaseResponce<CountryViewModel> CreateCountry(string countryViewModelName)
    {
        var baseResponce = new BaseResponce<CountryViewModel>();

        try
        {
            var countryName = _countryRepository.GetByName(countryViewModelName);

            if (countryName != null)
            {
                baseResponce.StatusCode = StatusCode.InternalServerError;
                return baseResponce;
            }
            var country = new Country()
            {
                Name = countryViewModelName,
            };
            _countryRepository.Create(country);
        }
        catch (Exception ex)
        {
            return new BaseResponce<CountryViewModel>()
            {
                Description = $"[GetCountry] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }
}