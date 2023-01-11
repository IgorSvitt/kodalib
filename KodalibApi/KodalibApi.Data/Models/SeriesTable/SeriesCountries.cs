using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.SeriesTable;

[Table("series_countries")]
public class SeriesCountries
{
    [Column("series_id")]
    public int SeriesId { get; set; }
    public  Series Series { get; set; }
    
    [Column("country_id")]
    public int CountryId { get; set; }
    public Country Country { get; set; }
}