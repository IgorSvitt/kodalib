using Kodalib.Service.Interfaces;
using KodalibApi.Data.ViewModels.Actor;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet("GetPeople",Name = "GetPeople")]
    public IEnumerable<PersonViewModel> GetPeople()
    {
        var responce = _personService.GetPeople();
        return responce.Data;
    }
    
    [HttpGet("GetPerson/{id}",Name = "GetPerson")]
    public PersonViewModel GetPerson(int id)
    {
        var responce = _personService.GetPerson(id);

        return responce.Data;
    }

    [HttpDelete("DeletePerson", Name = "DeletePerson")]
    public void DeletePerson(int id)
    {
        _personService.DeletePerson(id);
    }

    [HttpPost("CreatePerson", Name = "CreatePerson")]
    public void CreatePerson(PersonViewModel filmViewModels)
    {
        _personService.CreatePerson(filmViewModels);
    }

    [HttpPut("UpdatePerson", Name = "UpdatePerson")]
    public void UpdatePerson(int id, PersonViewModel personViewModel)
    {
        _personService.UpdatePerson(id, personViewModel);
    }

}