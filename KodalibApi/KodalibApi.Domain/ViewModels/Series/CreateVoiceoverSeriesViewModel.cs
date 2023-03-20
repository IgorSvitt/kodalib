namespace KodalibApi.Data.ViewModels.Series;

public class CreateVoiceoverSeriesViewModel
{
    public string Name { get; set; }

    public List<SeasonViewModel> Season { get; set; }

    public int CountEpisodes { get; set; }
    public int CountSeason { get; set; }
}