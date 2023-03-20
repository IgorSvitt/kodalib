using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.SeriesTable;

namespace KodalibApi.Data.Models;

[Table("countries")]
public class Country
{
    // Id of country
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    // Name of country
    [Column("name")]
    public string Name { get; set; }
    
    // List of films by country
    public List<FilmCountry>? FilmsList { get; set; }
    
    public List<SeriesCountries>? SeriesList { get; set; }
}