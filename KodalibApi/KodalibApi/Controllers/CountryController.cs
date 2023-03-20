using Kodalib.Service.Interfaces;
using KodalibApi.Data.Response;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;


[ApiController]
[Route("api/countries")]
[Produces("application/json")]
[Consumes("application/json")] 
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }
    
    [HttpGet(Name = "GetCountries")]
    public async Task<IBaseResponse> GetCountries()
    {
        var response = await _countryService.GetCountries(HttpContext.RequestAborted);
        return response;
    }
}