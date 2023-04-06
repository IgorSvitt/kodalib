using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.SeriesTable;

namespace KodalibApi.Data.Models.PeopleTables.SeriesPeople;

[Table("director_series")]
public class DirectorSeries
{
    [Column("series_id")]
    public int SeriesId { get; set; }

    [Column("director_id")]
    public int DirectorId { get; set; }

    public Person Director { get; set; }

    public Series Series { get; set; }
}