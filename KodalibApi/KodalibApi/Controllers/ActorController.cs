using Kodalib.Service.Interfaces;
using KodalibApi.Data.ViewModels.Actor;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorService _actorService;

    public ActorController(IActorService actorService)
    {
        _actorService = actorService;
    }
    
    [HttpGet("GetActors",Name = "GetActors")]
    public IEnumerable<PersonViewModel> GetActors()
    {
        var responce = _actorService.GetActors();
        return responce.Data;
    }

    [HttpGet("GetActor/{id}",Name = "GetActor")]
    public PersonViewModel GetActor(int id)
    {
        var responce = _actorService.GetActor(id);

        return responce.Data;
    }

    [HttpDelete("DeleteActor", Name = "DeleteActor")]
    public void DeleteActor(int id)
    {
        _actorService.DeleteActor(id);
    }

    [HttpPost("CreateActor", Name = "CreateActor")]
    public void CreateActor(PersonViewModel filmViewModels)
    {
        _actorService.CreateActor(filmViewModels);
    }

}