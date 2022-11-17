﻿using Kodalib.Interfaces.Base;
using KodalibApi.Data.Models;
using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Country;

namespace Kodalib.Service.Interfaces;

public interface ICountryService
{ 
    IBaseResponce<IEnumerable<CountryViewModel>> GetCountries();

    IBaseResponce<CountryViewModel> GetCountry(int id);
    
    IBaseResponce<Country> GetCountryByName(string name);

    IBaseResponce<bool> DeleteCountry(int id);

    IBaseResponce<CountryViewModel> CreateCountry(CountryViewModel countryViewModel);
}