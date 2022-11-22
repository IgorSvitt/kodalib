using Kodalib.Service.Interfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.ActorsTables;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Interfaces.ActorInterfaces;
using KodalibApi.Interfaces.RoleInterface;

namespace Kodalib.Service.Implementations;

public class ActorService: IActorService
{
    private readonly IActorRepository _actorRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ApplicationDbContext _context;

    public ActorService(IActorRepository actorRepository, IRoleRepository roleRepository,
        ApplicationDbContext context)
    {
        _actorRepository = actorRepository;
        _roleRepository = roleRepository;
        _context = context;
    }
    
    
    public IBaseResponce<IEnumerable<PersonViewModel>> GetActors()
    {
        var baseResponce = new BaseResponce<IEnumerable<PersonViewModel>>();

        try
        {
            var actors = _actorRepository.GetAllActors();
            if (actors.Result.Count == 0)
            {
                baseResponce.Description = "Actors 0 elements";
                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }

            baseResponce.Data = actors.Result;
            baseResponce.StatusCode = StatusCode.OK;


            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<IEnumerable<PersonViewModel>>()
            {
                Description = $"[GetActor] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<PersonViewModel> GetActor(int id)
    {
        var baseResponce = new BaseResponce<PersonViewModel>();

        try
        {
            var actor = _actorRepository.GetByIdFullDescription(id);
            if (actor == null)
            {
                baseResponce.Description = "Actor not found";
                baseResponce.StatusCode = StatusCode.ActorNotFound;
                return baseResponce;
            }

            baseResponce.Data = actor.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<PersonViewModel>()
            {
                Description = $"[GetActor] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<List<PersonViewModel>> GetActorByName(string name)
    {
        throw new NotImplementedException();
    }

    public IBaseResponce<bool> DeleteActor(int id)
    {
        var baseResponse = new BaseResponce<bool>();

        try
        {
            var actor = _actorRepository.GetById(id);
            if (actor == null)
            {
                baseResponse.Description = "Actor not found";
                baseResponse.StatusCode = StatusCode.ActorNotFound;
                baseResponse.Data = false;
                return baseResponse;
            }

            _actorRepository.Delete(actor.Result);
            baseResponse.Data = true;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponce<bool>()
            {
                Description = $"[GetActor] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public IBaseResponce<PersonViewModel> CreateActor(PersonViewModel actorViewModel)
    {
        var baseResponce = new BaseResponce<PersonViewModel>();

        try
        {
            var actorImdbId = _actorRepository.GetByImdbId(actorViewModel.ImdbId);

            if (actorImdbId != null)
            {
                throw new Exception("Film is exist");
            }

            var actor = new Person()
            {
                Id = actorViewModel.Id,
                PersonImdbId = actorViewModel.ImdbId,
                Name = actorViewModel.Name,
                Image = actorViewModel.Image,
                Summary = actorViewModel.Summary,
                BirthDate = actorViewModel.BirthDate,
                DeathDate = actorViewModel.DeathDate,
                Height = actorViewModel.Height,
            };
            _actorRepository.Create(actor);
            
            foreach (var name in actorViewModel.Role)
            {
                var nameActor = _roleRepository.GetByName(name);

                if (nameActor == null)
                {
                    _roleRepository.Create(new Role(){Name = name});
                    nameActor = _roleRepository.GetByName(name);
                }

                var idRole = nameActor.Id;
                
                var rolePerson = new RolePerson()
                {
                    PersonId = actor.Id,
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
                Description = $"[GetFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }
}