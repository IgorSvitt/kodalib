using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KodalibApi.Data.Models.SeriesTable;

[Table("season")]
public class Season
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("voiceover_id")]
    public int VoiceoverId { get; set; }
    public SeriesVoiceover Voiceover { get; set; }

    public int NumberSeason { get; set; }

    public List<Episodes> Episodes { get; set; }
}