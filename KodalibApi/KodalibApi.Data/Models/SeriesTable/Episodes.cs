using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.SeriesTable;

[Table("episodes")]
public class Episodes
{
    [Key] 
    [Column("id")]
    public int Id { get; set; }
    
    [Column("number_episode")]
    public short NumberEpisode { get; set; }

    [Column("link")]
    public string VideoLink { get; set; }

    [Column("image")]
    public string Image { get; set; }
    
    [Column("season_id")]
    public int? SeasonId { get; set; }
    public Season Season { get; set; }
}