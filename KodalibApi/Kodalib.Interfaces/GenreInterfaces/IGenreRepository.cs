using Kodalib.Interfaces.Base;
using KodalibApi.Data.Models;
using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Genre;

namespace Kodalib.Interfaces.GenreInterfaces;

public interface IGenreRepository: IBaseRepository<Genre>
{
    public Task<Genre> GetByName(string name);

    public Task<GenreViewModel> GetById(int id);

    public Task<List<GenreViewModel>> GetAllGenres();
}