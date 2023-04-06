using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.SeriesTable;

namespace KodalibApi.Data.Models.PeopleTables.SeriesPeople;

[Table("writer_series")]
public class WriterSeries
{
    [Column("series_id")]
    public int SeriesId { get; set; }

    [Column("writer_id")]
    public int WriterId { get; set; }

    public Person Writer { get; set; }

    public Series Series { get; set; }
}