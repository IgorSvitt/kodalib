using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.PeopleInterface;

public interface IPersonRepository: IBaseRepository<Person>
{
    Task<PersonViewModel> GetPersonById(int id, CancellationToken cancellationToken);
    
    Task<PersonViewModel?> GetPersonByName(string person,CancellationToken cancellationToken);
    Task<IdViewModel?> GetPersonIdByName(string person,CancellationToken cancellationToken);

    Task<IdViewModel> CreatePerson(string person, CancellationToken cancellationToken);

}