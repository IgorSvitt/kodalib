using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.People;

namespace Kodalib.Service.Interfaces;

public interface IRoleService
{
    IBaseResponce<IEnumerable<RoleViewModel>> GetRoles();

    IBaseResponce<RoleViewModel> GetRole(int id);
    
    IBaseResponce<RoleViewModel> GetRoleByName(string name);

    IBaseResponce<bool> DeleteRole(int id);

    IBaseResponce<RoleViewModel> CreateRole(string countryViewModelName);
}