using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.ActorsTables;

namespace KodalibApi.Data.Models;

[Table("actors")]
public class Actor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("actors_imdb_id")]
    public string ActorImdbId { get; set; }
    
    [Column("name")]
    public string Name { get; set; }

    [Column("roles")]
    public List<string>? Role { get; set; }

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
}