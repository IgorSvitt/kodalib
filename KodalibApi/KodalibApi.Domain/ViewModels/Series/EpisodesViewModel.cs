﻿namespace KodalibApi.Data.ViewModels.Series;

public class EpisodesViewModel
{
    public Guid? Id { get; set; }
    
    public short NumberEpisode { get; set; }
    
    public string VideoLink { get; set; }
    
    public string? Image { get; set; }
}