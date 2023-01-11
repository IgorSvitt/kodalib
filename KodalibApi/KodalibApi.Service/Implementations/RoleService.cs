using Kodalib.Service.Interfaces;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Responce;
using KodalibApi.Data.Responce.Enum;
using KodalibApi.Data.ViewModels.People;
using KodalibApi.Interfaces.RoleInterface;

namespace Kodalib.Service.Implementations;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleService)
    {
        _roleRepository = roleService;
    }

    public IBaseResponce<IEnumerable<RoleViewModel>> GetRoles()
    {
        var baseResponce = new BaseResponce<IEnumerable<RoleViewModel>>();

        try
        {
            var roles = _roleRepository.GetAllGenres();
            if (roles.Result.Count == 0)
            {
                baseResponce.Description = "Found 0 elements";
                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }

            baseResponce.Data = roles.Result;
            baseResponce.StatusCode = StatusCode.OK;


            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<IEnumerable<RoleViewModel>>()
            {
                Description = $"[GetRoles] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<RoleViewModel> GetRole(int id)
    {
        var baseResponce = new BaseResponce<RoleViewModel>();

        try
        {
            var role = _roleRepository.GetByIdFullDescription(id);
            if (role == null)
            {
                baseResponce.Description = "Role not found";
                baseResponce.StatusCode = StatusCode.RoleNotFound;
                return baseResponce;
            }

            baseResponce.Data = role.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<RoleViewModel>()
            {
                Description = $"[GetRole] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<RoleViewModel> GetRoleByName(string name)
    {
        var baseResponce = new BaseResponce<RoleViewModel>();

        try
        {
            var role = _roleRepository.GetByNameFullDescription(name);
            if (role == null)
            {
                baseResponce.Description = "Role not found";
                baseResponce.StatusCode = StatusCode.RoleNotFound;
                return baseResponce;
            }

            baseResponce.Data = role.Result;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<RoleViewModel>()
            {
                Description = $"[GetRole] : {ex.Message}"
            };
        }
    }

    public IBaseResponce<bool> DeleteRole(int id)
    {
        var baseResponse = new BaseResponce<bool>();

        try
        {
            var role = _roleRepository.GetById(id);
            if (role == null)
            {
                baseResponse.Description = "Country not found";
                baseResponse.StatusCode = StatusCode.CountryNotFound;
                baseResponse.Data = false;
                return baseResponse;
            }

            _roleRepository.Delete(role.Result);
            baseResponse.Data = true;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponce<bool>()
            {
                Description = $"[GetRole] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public IBaseResponce<RoleViewModel> CreateRole(string roleViewModel)
    {
        var baseResponce = new BaseResponce<RoleViewModel>();

        try
        {
            var roleName = _roleRepository.GetByName(roleViewModel);

            if (roleName != null)
            {
                baseResponce.StatusCode = StatusCode.InternalServerError;
                return baseResponce;
            }

            var role = new Role()
            {
                Name = roleViewModel,
            };
            _roleRepository.Create(role);
        }
        catch (Exception ex)
        {
            return new BaseResponce<RoleViewModel>()
            {
                Description = $"[GetCountry] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }

    public IBaseResponce<RoleViewModel> UpdateRole(int id, RoleViewModel roleViewModel)
    {
        var baseResponce = new BaseResponce<RoleViewModel>();

        try
        {
            var role = _roleRepository.GetById(id);

            if (role.Result == null)
            {
                CreateRole(roleViewModel.Name);
                return baseResponce;
            }

            role.Result.Name = roleViewModel.Name;
            _roleRepository.Update(role.Result);
        }
        catch (Exception ex)
        {
            return new BaseResponce<RoleViewModel>()
            {
                Description = $"[GetCountry] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponce;
    }
}