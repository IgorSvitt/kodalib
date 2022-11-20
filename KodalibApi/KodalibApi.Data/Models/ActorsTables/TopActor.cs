using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.ActorsTables;

[Table("top_actors")]
public class TopActor
{
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("actors_id")]
    public int ActorId { get; set; }
    
    public Actor Actor { get; set; }

    public Film Film { get; set; }
}