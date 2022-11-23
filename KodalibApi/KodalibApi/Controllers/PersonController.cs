using Kodalib.Service.Interfaces;
using KodalibApi.Data.ViewModels.Actor;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService actorService)
    {
        _personService = actorService;
    }
    
    [HttpGet("GetPersons",Name = "GetPersons")]
    public IEnumerable<PersonViewModel> GetPerson()
    {
        var responce = _personService.GetPeople();
        return responce.Data;
    }

    [HttpGet("GetPerson/{id}",Name = "GetPerson")]
    public PersonViewModel GetActor(int id)
    {
        var responce = _personService.GetPerson(id);

        return responce.Data;
    }

    [HttpDelete("DeletePerson", Name = "DeletePerson")]
    public void DeleteActor(int id)
    {
        _personService.DeletePerson(id);
    }

    [HttpPost("CreatePerson", Name = "CreatePerson")]
    public void CreateActor(PersonViewModel filmViewModels)
    {
        _personService.CreatePerson(filmViewModels);
    }

}