using KodalibApi.Data.Models;
using KodalibApi.Data.Responce;
using KodalibApi.Data.ViewModels.Genre;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.GenreInterfaces;

public interface IGenreRepository: IBaseRepository<Genre>
{
    public Task<GenreViewModel> GetByNameFullDescription(string name);

    public Task<GenreViewModel> GetByIdFullDescription(int id);

    public Task<List<GenreViewModel>> GetAllGenres();
}