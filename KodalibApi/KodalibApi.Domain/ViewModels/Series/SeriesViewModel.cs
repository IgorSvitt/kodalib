using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Genre;

namespace KodalibApi.Data.ViewModels.Series;

public class SeriesViewModel
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

    public List<CountryViewModel>? Countries { get; set; }
    
    public List<GenreViewModel>? Genres { get; set; }

    public List<CharacterViewModel>? Actors { get; set; }

    public List<CharacterViewModel>? Writers { get; set; }
    
    public List<CharacterViewModel>? Directors { get; set; }
    
    public List<SeriesVoiceoverViewModel> Voiceovers { get; set; }
}