using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    [Column("summary")]
    public string? Summary { get; set; }
    
    [Column("birth_date")]
    public string? BirthDate { get; set; }

    [Column("death_date")]
    public string? DeathDate { get; set; }

    // List of top actors in films by actors
    public List<TopActor>? TopActors { get; set; }

    // List of films by actors
    public List<Character>? Films { get; set; }
    
    public List<RolePerson>? Role { get; set; }
    
    public List<Writers>? Writers { get; set; }
    
    public List<Director>? Directors { get; set; }
    
    public List<CharacterSeries>? Series { get; set; }
    public List<WriterSeries>? WriterSeries { get; set; }
    public List<DirectorSeries>? DirectorSeries { get; set; }
    
    
}