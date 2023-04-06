namespace KodalibApi.Data.ViewModels.Series;

public class SeasonViewModel
{
    public int? Id { get; set; }

    public int NumberSeason { get; set; }

    public List<EpisodesViewModel>? Episodes { get; set; }
}