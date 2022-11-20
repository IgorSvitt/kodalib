using Kodalib.Service.Interfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Interfaces.ActorInterfaces;

namespace Kodalib.Service.Implementations;

public class ActorService: IActorService
{
    private readonly IActorRepository _actorRepository;

    public ActorService(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }
    
    
    public IBaseResponce<IEnumerable<ActorViewModel>> GetActors()
    {
        var baseResponce = new BaseResponce<IEnumerable<ActorViewModel>>();

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
            return new BaseResponce<IEnumerable<ActorViewModel>>()
            {
                Description = $"[GetActor] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<ActorViewModel> GetActor(int id)
    {
        var baseResponce = new BaseResponce<ActorViewModel>();

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
            return new BaseResponce<ActorViewModel>()
            {
                Description = $"[GetActor] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<List<ActorViewModel>> GetActorByName(string name)
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

    public IBaseResponce<ActorViewModel> CreateActor(ActorViewModel actorViewModel)
    {
        var baseResponce = new BaseResponce<ActorViewModel>();

        try
        {
            var actorImdbId = _actorRepository.GetByImdbId(actorViewModel.ImdbId);

            if (actorImdbId != null)
            {
                throw new Exception("Film is exist");
            }

            var actor = new Actor()
            {
                Id = actorViewModel.Id,
                ActorImdbId = actorViewModel.ImdbId,
                Name = actorViewModel.Name,
                Role = actorViewModel.Role,
                Image = actorViewModel.Image,
                Summary = actorViewModel.Summary,
                BirthDate = actorViewModel.BirthDate,
                DeathDate = actorViewModel.DeathDate,
                Height = actorViewModel.Height,
            };
            _actorRepository.Create(actor);
        }
        catch (Exception ex)
        {
            return new BaseResponce<ActorViewModel>()
            {
                Description = $"[GetFilm] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }
}