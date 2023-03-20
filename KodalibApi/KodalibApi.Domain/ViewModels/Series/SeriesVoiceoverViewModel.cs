namespace KodalibApi.Data.ViewModels.Series;

public class SeriesVoiceoverViewModel
{

    public int Id { get; set; }
    public string Voiceover { get; set; }

    public int CountSeasons { get; set; }
    public int CountEpisodes { get; set; }
    
    public List<SeasonViewModel> Seasons { get; set; }
}