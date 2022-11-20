using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Actor;

namespace Kodalib.Service.Interfaces;

public interface IActorService
{
    IBaseResponce<IEnumerable<ActorViewModel>> GetActors();

    IBaseResponce<ActorViewModel> GetActor(int id);
    
    IBaseResponce<List<ActorViewModel>> GetActorByName(string name);

    IBaseResponce<bool> DeleteActor(int id);

    IBaseResponce<ActorViewModel> CreateActor(ActorViewModel actorViewModelName);
}