using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Genre;
using KodalibApi.Interfaces.Base;

namespace KodalibApi.Interfaces.GenreInterfaces;

public interface IGenreRepository: IBaseRepository<Genre>
{
    Task<List<GenreViewModel>> GetGenres(CancellationToken cancellationToken);
    
    Task<GenreViewModel?> GetGenreByName(string genre,CancellationToken cancellationToken);
    
    Task<IdViewModel?> GetGenreIdByName(string genre,CancellationToken cancellationToken);

    Task<IdViewModel> CreateGenre(string genre, CancellationToken cancellationToken);
}