using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.PeopleTables;

[Table("person")]
public class Person
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("person_imdb_id")]
    public string PersonImdbId { get; set; }
    
    [Column("name")]
    public string Name { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    [Column("summary")]
    public string? Summary { get; set; }
    
    [Column("birth_date")]
    public string? BirthDate { get; set; }

    [Column("death_date")]
    public string? DeathDate { get; set; }
    
    [Column("height")]
    public string? Height { get; set; }

    // List of top actors in films by actors
    public List<TopActor>? TopActors { get; set; }

    // List of films by actors
    public List<Character>? Films { get; set; }
    
    public List<RolePerson>? Role { get; set; }
    
    public List<WritersFilms>? WritersFilms { get; set; }
}