using KodalibApi.Data.Response;
using KodalibApi.Data.ViewModels.Actor;

namespace Kodalib.Service.Interfaces;

public interface IPersonService
{
    Task<IBaseResponse> GetPerson(int id, CancellationToken cancellationToken);
}