using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.VoiceoverTable;

namespace KodalibApi.Data.Models.FIlmTables;

[Table("film_voiceover")]
public class FilmVoiceover
{
    [Column("film_id")] 
    public int FilmId { get; set; }
    public Film Film { get; set; }

    [Column("voiceover_id")] 
    public int VoiceoverId { get; set; }
    public Voiceover Voiceover { get; set; }
    
    public string Link { get; set; }
}