using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Series;

namespace KodalibApi.Data.ViewModels.Actor;

public class PersonViewModel
{
    public int Id { get; set; }
    
    public string? KinopoiskId { get; set; }
    
    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? Summary { get; set; }

    public List<FilmTitleViewModel> Films { get; set; }
    
    public List<SeriesTitleViewModel> Series { get; set; }
}