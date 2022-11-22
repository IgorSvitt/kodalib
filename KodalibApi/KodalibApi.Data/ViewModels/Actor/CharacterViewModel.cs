using KodalibApi.Data.ViewModels.Film;

namespace KodalibApi.Data.ViewModels.Actor;

public class CharacterViewModel
{
    public int? Id { get; set; }
    public string? Role { get; set; }
    
    public string Actor { get; set; }

    public string ActorImdbId { get; set; }
}
