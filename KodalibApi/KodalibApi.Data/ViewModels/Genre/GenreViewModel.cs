using KodalibApi.Data.ViewModels.Film;

namespace KodalibApi.Data.ViewModels.Genre;

public class GenreViewModel
{
    public int? Id { get; set; }
    
    public string? Name { get; set; }
    
    public List<FilmIdAndTitleViewModel>? FilmTitle { get; set; }
}