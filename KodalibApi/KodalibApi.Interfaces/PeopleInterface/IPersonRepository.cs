using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.PeopleInterface;

public interface IPersonRepository: IBaseRepository<Person>
{
    Task<PersonViewModel> GetByIdFullDescription(int id);

    Task<List<PersonViewModel>> GetAllPeople();
    
    Task<PersonViewModel> GetByImdbIdFullDescription(string name);
    
    Person GetByImdbId(string imdbId);
    
}