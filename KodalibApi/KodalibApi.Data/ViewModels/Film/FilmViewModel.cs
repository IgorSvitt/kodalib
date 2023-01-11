using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Genre;

namespace KodalibApi.Data.ViewModels.Film;

public class FilmViewModels
{
    public int? Id { get; set; }
    public string? KinopoiskId { get; set; }

    public string Title { get; set; }
    
    public string? Poster { get; set; }

    public short? Year { get; set; }

    public string? Duration { get; set; }

    public string? Plot { get; set; }

    public string? KinopoiskRating { get; set; }
    
    public string? KodalibRating { get; set; }

    public string? YoutubeTrailer { get; set; }
    
    public string? ThumbnailUrl { get; set; }
    
    public string LinkVideo { get; set; }
    
    public List<CountryNameViewModel>? FilmsCountriesList { get; set; }
    
    public List<GenreNameViewModel>? FilmsGenreList { get; set; }

    public List<CharacterViewModel>? ActorsList { get; set; }
    
    public List<TopActorViewModel>? TopActorsList { get; set; }
    
    public List<WriterViewModel>? WritersList { get; set; }
    
    public List<DirectorViewModel>? DirectorList { get; set; }
    
}