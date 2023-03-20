using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.PeopleTables.FilmPeople;
using KodalibApi.Data.Models.PeopleTables.SeriesPeople;
using KodalibApi.Data.Models.SeriesTable;

namespace KodalibApi.Data.Models.PeopleTables;

[Table("person")]
public class Person
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("person_kinopoisk_id")]
    public string? PersonKinopoiskId { get; set; }
    
    [Column("name")]
    public string? Name { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    // List of films by actors
    public List<Character>? Films { get; set; }
    public List<Writer>? Writers { get; set; }
    public List<Director>? Directors { get; set; }
    
    public List<CharacterSeries>? Series { get; set; }
    public List<WriterSeries>? WriterSeries { get; set; }
    public List<DirectorSeries>? DirectorSeries { get; set; }
    
    
}