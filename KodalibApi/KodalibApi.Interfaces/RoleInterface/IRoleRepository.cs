using KodalibApi.Data.Models.ActorsTables;
using KodalibApi.Data.ViewModels.People;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.RoleInterface;

public interface IRoleRepository: IBaseRepository<Role>
{
    public Task<RoleViewModel> GetByNameFullDescription(string name);

    public Task<RoleViewModel> GetByIdFullDescription(int id);

    public Task<List<RoleViewModel>> GetAllGenres();
}