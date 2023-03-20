using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.SeriesTable;

namespace KodalibApi.Data.Models.PeopleTables.SeriesPeople;

[Table("character_series")]
public class CharacterSeries
{
    [Column("series_id")]
    public int SeriesId { get; set; }

    [Column("actors_id")]
    public int ActorId { get; set; }
    public Person Actor { get; set; }

    public Series Series { get; set; }
}