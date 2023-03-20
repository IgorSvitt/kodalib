using KodalibApi.Data.ViewModels.Series;

namespace KodalibApi.Data.ViewModels.CreateViewModels;

public class CreateSeriesViewModel
{
    public string? KinopoiskId { get; set; }

    public string Title { get; set; }
    
    public string? Poster { get; set; }

    public short? Year { get; set; }

    public string? Duration { get; set; }

    public string? Plot { get; set; }

    public string? KinopoiskRating { get; set; }
    
    public string? KodalibRating { get; set; }

    public string? YoutubeTrailer { get; set; }

    public List<string>? Countries { get; set; }
    
    public List<string>? Genres { get; set; }

    public List<string>? Writers { get; set; }
    
    public List<string>? Directors { get; set; }
    public List<string>? Actors { get; set; }
    
    public List<CreateVoiceoverSeriesViewModel>? Voiceover { get; set; }
}