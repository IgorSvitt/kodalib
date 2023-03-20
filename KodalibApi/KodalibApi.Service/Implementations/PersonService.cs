using Kodalib.Service.Interfaces;
using KodalibApi.Dal.Context;
using KodalibApi.Data.Response;
using KodalibApi.Data.Response.Enum;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Series;
using KodalibApi.Interfaces.PeopleInterface;

namespace Kodalib.Service.Implementations;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<IBaseResponse> GetPerson(int id, CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<PersonViewModel>();

        try
        {
            var person = await _personRepository.GetPersonById(id, cancellationToken);

            if (person == null)
            {
                return new ErrorResponse()
                {
                    Description = "Person not found",
                    StatusCode = StatusCode.NotFound
                };
            }

            baseResponse.Data = person;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new ErrorResponse()
            {
                Description = $"[GetPerson] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    // public IBaseResponce<IEnumerable<PersonViewModel>> GetPeople()
    // {
    //     var baseResponce = new BaseResponce<IEnumerable<PersonViewModel>>();
    //
    //     try
    //     {
    //         var person = _personRepository.GetAllPeople();
    //         if (person.Result.Count == 0)
    //         {
    //             baseResponce.Description = "Person 0 elements";
    //             baseResponce.StatusCode = StatusCode.OK;
    //             return baseResponce;
    //         }
    //
    //         baseResponce.Data = person.Result;
    //         baseResponce.StatusCode = StatusCode.OK;
    //
    //
    //         return baseResponce;
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<IEnumerable<PersonViewModel>>()
    //         {
    //             Description = $"[GetPerson] : {ex.Message}"
    //         };
    //     }
    // }
    //
    // public IBaseResponce<PersonViewModel> GetPerson(int id)
    // {
    //     var baseResponce = new BaseResponce<PersonViewModel>();
    //
    //     try
    //     {
    //         var person = _personRepository.GetByIdFullDescription(id);
    //         if (person == null)
    //         {
    //             baseResponce.Description = "Person not found";
    //             baseResponce.StatusCode = StatusCode.PersonNotFound;
    //             return baseResponce;
    //         }
    //
    //         baseResponce.Data = person.Result;
    //         return baseResponce;
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<PersonViewModel>()
    //         {
    //             Description = $"[GetPerson] : {ex.Message}"
    //         };
    //     }
    // }
    //
    // public IBaseResponce<List<PersonViewModel>> GetPersonByName(string name)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public IBaseResponce<bool> DeletePerson(int id)
    // {
    //     var baseResponse = new BaseResponce<bool>();
    //
    //     try
    //     {
    //         var person = _personRepository.GetById(id);
    //         if (person == null)
    //         {
    //             baseResponse.Description = "Person not found";
    //             baseResponse.StatusCode = StatusCode.PersonNotFound;
    //             baseResponse.Data = false;
    //             return baseResponse;
    //         }
    //
    //         _personRepository.Delete(person.Result);
    //         baseResponse.Data = true;
    //         return baseResponse;
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<bool>()
    //         {
    //             Description = $"[GetPerson] : {ex.Message}",
    //             StatusCode = StatusCode.InternalServerError
    //         };
    //     }
    // }
    //
    // public IBaseResponce<PersonViewModel> CreatePerson(PersonViewModel personViewModel)
    // {
    //     var baseResponce = new BaseResponce<PersonViewModel>();
    //
    //     try
    //     {
    //         var personImdbId = _personRepository.GetById(personViewModel.Id);
    //
    //         if (personImdbId.Result != null)
    //         {
    //             throw new Exception("Person is exist");
    //         }
    //
    //         var person = new Person()
    //         {
    //             Id = personViewModel.Id,
    //             PersonKinopoiskId = personViewModel.KinopoiskId,
    //             Name = personViewModel.Name,
    //             Image = personViewModel.Image,
    //             Summary = personViewModel.Summary,
    //             BirthDate = personViewModel.BirthDate,
    //             DeathDate = personViewModel.DeathDate,
    //         };
    //         _personRepository.Create(person);
    //
    //         foreach (var name in personViewModel.Role)
    //         {
    //             Role role = _roleRepository.GetByName(name);
    //
    //             if (role == null)
    //             {
    //                 _roleRepository.Create(new Role() {Name = name});
    //                 role = _roleRepository.GetByName(name);
    //             }
    //
    //             int idRole = role.Id;
    //
    //             RolePerson rolePerson = new RolePerson()
    //             {
    //                 PersonId = person.Id,
    //                 RoleId = idRole,
    //             };
    //
    //             _context.RolePersons.Add(rolePerson);
    //             _context.SaveChanges();
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BaseResponce<PersonViewModel>()
    //         {
    //             Description = $"[GetPerson] : {ex.Message}",
    //             StatusCode = StatusCode.InternalServerError
    //         };
    //     }
    //
    //     return baseResponce;
    // }
    //
    // public IBaseResponce<PersonViewModel> UpdatePerson(int id, PersonViewModel personViewModel)
    // {
    //     var baseResponce = new BaseResponce<PersonViewModel>();
    //
    //     try
    //     {
    //         var person = _personRepository.GetById(id);
    //
    //         if (person.Result == null)
    //         {
    //             CreatePerson(personViewModel);
    //             return baseResponce;
    //         }
    //
    //         person.Result.PersonKinopoiskId = personViewModel.KinopoiskId;
    //         person.Result.Name = personViewModel.Name;
    //         person.Result.Image = personViewModel.Image;
    //         person.Result.Summary = personViewModel.Summary;
    //         person.Result.BirthDate = personViewModel.BirthDate;
    //         person.Result.DeathDate = personViewModel.DeathDate;
    //         _personRepository.Update(person.Result);
    //
    //         var actorRoles = _context.RolePersons.Where(x => x.PersonId == id);
    //         
    //         foreach (var role in actorRoles)
    //         {
    //             _context.RolePersons.Remove(role);
    //
    //         }
    //         
    //         _context.SaveChanges();
    //
    //         foreach (var name in personViewModel.Role)
    //         {
    //             var role = _roleRepository.GetByName(name);
    //
    //             if (role == null)
    //             {
    //                 _roleRepository.Create(new Role() {Name = name});
    //                 role = _roleRepository.GetByName(name);
    //             }
    //
    //             var rolePerson = new RolePerson()
    //             {
    //                 PersonId = id,
    //                 RoleId = role.Id,
    //             };
    //             
    //             _context.RolePersons.Add(rolePerson);
    //             _context.SaveChanges();
    //         }
    //         
    //     }
    //     catch (Exception ex)
    //     { 
    //         return new BaseResponce<PersonViewModel>()
    //         {
    //             Description = $"[GetPerson] : {ex.Message}",
    //             StatusCode = StatusCode.InternalServerError
    //         };
    //     }
    //
    //     return baseResponce;
    // }
    
}