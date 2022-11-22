using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.FIlmTables;


[Table("films_countries")]
public class FilmsCountries
{
    [Column("films_id")]
    public int FilmsId { get; set; }
    public  Film Film { get; set; }
    [Column("country_id")]
    public int CountryId { get; set; }
    public Country Country { get; set; }
    
}