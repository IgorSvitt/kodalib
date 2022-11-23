using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.PeopleTables;

[Table("character")]
public class Character
{
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("actors_id")]
    public int ActorId { get; set; }
    
    [Column("role")]
    public string? Role { get; set; }
    
    public Person Actor { get; set; }

    public Film Film { get; set; }
}