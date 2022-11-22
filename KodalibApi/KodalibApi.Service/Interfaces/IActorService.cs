using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Actor;

namespace Kodalib.Service.Interfaces;

public interface IActorService
{
    IBaseResponce<IEnumerable<PersonViewModel>> GetActors();

    IBaseResponce<PersonViewModel> GetActor(int id);
    
    IBaseResponce<List<PersonViewModel>> GetActorByName(string name);

    IBaseResponce<bool> DeleteActor(int id);

    IBaseResponce<PersonViewModel> CreateActor(PersonViewModel actorViewModelName);
}