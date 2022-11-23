using Kodalib.Service.Interfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Interfaces.PeopleInterface;
using KodalibApi.Interfaces.RoleInterface;

namespace Kodalib.Service.Implementations;

public class PersonService: IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ApplicationDbContext _context;

    public PersonService(IPersonRepository personRepository, IRoleRepository roleRepository,
        ApplicationDbContext context)
    {
        _personRepository = personRepository;
        _roleRepository = roleRepository;
        _context = context;
    }
    
    
    public IBaseResponce<IEnumerable<PersonViewModel>> GetPeople()
    {
        var baseResponce = new BaseResponce<IEnumerable<PersonViewModel>>();

        try
        {
            var person = _personRepository.GetAllPeople();
            if (person.Result.Count == 0)
            {
                baseResponce.Description = "Person 0 elements";
                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }

            baseResponce.Data = person.Result;
            baseResponce.StatusCode = StatusCode.OK;


            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<IEnumerable<PersonViewModel>>()
            {
                Description = $"[GetPerson] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<PersonViewModel> GetPerson(int id)
    {
        var baseResponce = new BaseResponce<PersonViewModel>();

        try
        {
            var person = _personRepository.GetByIdFullDescription(id);
            if (person == null)
            {
                baseResponce.Description = "Person not found";
                baseResponce.StatusCode = StatusCode.PersonNotFound;
                return baseResponce;
            }

            baseResponce.Data = person.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<PersonViewModel>()
            {
                Description = $"[GetPerson] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<List<PersonViewModel>> GetPersonByName(string name)
    {
        throw new NotImplementedException();
    }

    public IBaseResponce<bool> DeletePerson(int id)
    {
        var baseResponse = new BaseResponce<bool>();

        try
        {
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                baseResponse.Description = "Person not found";
                baseResponse.StatusCode = StatusCode.PersonNotFound;
                baseResponse.Data = false;
                return baseResponse;
            }

            _personRepository.Delete(person.Result);
            baseResponse.Data = true;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponce<bool>()
            {
                Description = $"[GetPerson] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public IBaseResponce<PersonViewModel> CreatePerson(PersonViewModel personViewModel)
    {
        var baseResponce = new BaseResponce<PersonViewModel>();

        try
        {
            var personImdbId = _personRepository.GetByImdbId(personViewModel.ImdbId);

            if (personImdbId != null)
            {
                throw new Exception("Film is exist");
            }

            var person = new Person()
            {
                Id = personViewModel.Id,
                PersonImdbId = personViewModel.ImdbId,
                Name = personViewModel.Name,
                Image = personViewModel.Image,
                Summary = personViewModel.Summary,
                BirthDate = personViewModel.BirthDate,
                DeathDate = personViewModel.DeathDate,
                Height = personViewModel.Height,
            };
            _personRepository.Create(person);
            
            foreach (var name in personViewModel.Role)
            {
                var role = _roleRepository.GetByName(name);

                if (role == null)
                {
                    _roleRepository.Create(new Role(){Name = name});
                    role = _roleRepository.GetByName(name);
                }

                var idRole = role.Id;
                
                var rolePerson = new RolePerson()
                {
                    PersonId = person.Id,
                    RoleId = idRole,
                };
                _context.RolePersons.Add(rolePerson);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            return new BaseResponce<PersonViewModel>()
            {
                Description = $"[GetPerson] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }
}