using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.ActorsTables;

[Table("character")]
public class Character
{
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("actors_id")]
    public int ActorId { get; set; }
    
    [Column("role")]
    public string? Role { get; set; }
    
    public Actor Actor { get; set; }

    public Film Film { get; set; }
}