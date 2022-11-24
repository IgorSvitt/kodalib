using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.ViewModels.Film;

namespace KodalibApi.Data.ViewModels.Actor;

public class PersonViewModel
{
    public int Id { get; set; }
    
    public string ImdbId { get; set; }
    
    public string Name { get; set; }

    public List<string>? Role { get; set; }

    public string? Image { get; set; }

    public string? Summary { get; set; }
    
    public string? BirthDate { get; set; }

    public string? DeathDate { get; set; }
    
    public string? Height { get; set; }

    public List<FilmIdAndTitleViewModel>? Films { get; set; }
}