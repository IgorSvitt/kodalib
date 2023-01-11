using KodalibApi.Data.ViewModels.Film;

namespace KodalibApi.Data.ViewModels.Actor;

public class CharacterViewModel
{
    public int? Id { get; set; }
    public string? Role { get; set; }
    
    public string? Name { get; set; }
    public string? ActorKinopoiskId { get; set; }
}
