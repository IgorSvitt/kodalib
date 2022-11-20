using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.ActorInterfaces;

public interface IActorRepository: IBaseRepository<Actor>
{
    Task<ActorViewModel> GetByIdFullDescription(int id);

    Task<List<ActorViewModel>> GetAllActors();
    
    Task<ActorViewModel> GetByImdbIdFullDescription(string name);
    
    Task<Actor> GetByImdbId(string imdbId);
    
}