using KodalibApi.Data.Models;
using KodalibApi.Data.Models.ActorsTables;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.ActorInterfaces;

public interface IActorRepository: IBaseRepository<Person>
{
    Task<PersonViewModel> GetByIdFullDescription(int id);

    Task<List<PersonViewModel>> GetAllActors();
    
    Task<PersonViewModel> GetByImdbIdFullDescription(string name);
    
    Person GetByImdbId(string imdbId);
    
}