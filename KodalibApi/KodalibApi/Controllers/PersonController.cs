using Kodalib.Service.Interfaces;
using KodalibApi.Data.Response;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/people")]
[Produces("application/json")] 
[Consumes("application/json")] 
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet("{id}", Name = "GetPeople")]
    public async Task<IBaseResponse> GetPerson(int id)
    {
        var response = await _personService.GetPerson(id, HttpContext.RequestAborted);
        return response;
    }

}