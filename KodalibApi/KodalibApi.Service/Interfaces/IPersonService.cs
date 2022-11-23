using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Actor;

namespace Kodalib.Service.Interfaces;

public interface IPersonService
{
    IBaseResponce<IEnumerable<PersonViewModel>> GetPeople();

    IBaseResponce<PersonViewModel> GetPerson(int id);
    
    IBaseResponce<List<PersonViewModel>> GetPersonByName(string name);

    IBaseResponce<bool> DeletePerson(int id);

    IBaseResponce<PersonViewModel> CreatePerson(PersonViewModel personViewModelName);
}