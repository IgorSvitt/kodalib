using KodalibApi.Data.Models;
using KodalibApi.Data.Response;
using KodalibApi.Data.ViewModels.Genre;
using KodalibApi.Interfaces.Base;

namespace Kodalib.Service.Interfaces;

public interface IGenreService
{
    Task<IBaseResponse> GetGenres(CancellationToken cancellationToken);
}