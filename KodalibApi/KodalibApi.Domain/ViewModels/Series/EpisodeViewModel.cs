namespace KodalibApi.Data.ViewModels.Series;

public class EpisodeViewModel
{
    public int? Id { get; set; }
    
    public short NumberEpisode { get; set; }
    
    public string VideoLink { get; set; }
    
    public string? Image { get; set; }

    public string SeriesTitle { get; set; }

    public int SeriesId { get; set; }

    public int Season { get; set; }

    public int SeasonId { get; set; }

    public string Voiceover { get; set; }

    public int VoiceoverId { get; set; }
}