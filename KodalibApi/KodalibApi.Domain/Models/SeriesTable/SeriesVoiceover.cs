using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.VoiceoverTable;

namespace KodalibApi.Data.Models.SeriesTable;

[Table("series_voiceover")]
public class SeriesVoiceover
{
    [Column("series_id")] 
    public int SeriesId { get; set; }
    public Series Series { get; set; }

    [Column("voiceover_id")] 
    public int VoiceoverId { get; set; }
    public Voiceover Voiceover { get; set; }

    [Column("count_season")]
    public int CountSeasons { get; set; }
    [Column("count_episodes")]
    public int CountEpisodes { get; set; }
    public List<Season> Seasons { get; set; }
}