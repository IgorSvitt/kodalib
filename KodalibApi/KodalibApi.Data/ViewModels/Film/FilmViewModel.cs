using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Actor;

namespace KodalibApi.Data.ViewModels.Film;

public class FilmViewModels
{
    public int Id { get; set; }
    public string ImdbId { get; set; }

    public string Title { get; set; }

    public string? Poster { get; set; }

    public short? Year { get; set; }

    public string? Duration { get; set; }

    public string? Plot { get; set; }

    public short? ImdbRating { get; set; }

    public string? Budget { get; set; }
    
    public string? GrossWorldwide { get; set; }
    
    public string? YoutubeTrailer { get; set; }
    
    public List<string>? FilmsCountriesList { get; set; }
    
    public List<string>? FilmsGenreList { get; set; }

    public List<CharacterViewModel>? ActorsList { get; set; }
    
    public List<TopActorViewModel>? TopActorsList { get; set; }
    
    public List<WriterViewModel>? WritersList { get; set; }
    
    public List<DirectorViewModel>? DirectorList { get; set; }
}