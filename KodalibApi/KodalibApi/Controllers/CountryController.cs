using Kodalib.Service.Interfaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Country;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }
    
    [HttpGet("GetCountries")]
    public IEnumerable<CountryViewModel> GetCountries()
    {
        var responce = _countryService.GetCountries();
        return responce.Data;
    }
    
    [HttpGet("GetCountry/{id}")]
    public CountryViewModel GetCountry(int id)
    {
        var responce = _countryService.GetCountry(id);
        return responce.Data;
    }
    
    [HttpGet("GetCountryByName/{name}")]
    public Country GetCountryByName(string name)
    {
        var responce = _countryService.GetCountryByName(name);
        return responce.Data;
    }

    [HttpPost("CreateCountry")]
    public void CreateCountry(CountryViewModel countryViewModel)
    {
        var responce = _countryService.CreateCountry(countryViewModel);
    }

    [HttpDelete("DeleteCountry")]
    public void DeleteCountry(int id)
    {
        var responce = _countryService.DeleteCountry(id);
    }
}