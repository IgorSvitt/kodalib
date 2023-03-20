using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.SeriesTable;

namespace KodalibApi.Data.Models.VoiceoverTable;

[Table("voiceover")]
public class Voiceover
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public List<FilmVoiceover> Films { get; set; }
    public List<SeriesVoiceover> Series { get; set; }
}