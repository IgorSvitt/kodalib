using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.FIlmTables;


[Table("film_country")]
public class FilmCountry
{
    [Column("film_id")]
    public int FilmId { get; set; }
    public  Film Film { get; set; }
    [Column("country_id")]
    public int CountryId { get; set; }
    public Country Country { get; set; }
    
}