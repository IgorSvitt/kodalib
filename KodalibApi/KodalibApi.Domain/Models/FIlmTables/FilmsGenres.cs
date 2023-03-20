using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.FilmTables;

[Table("film_genre")]
public class FilmGenre
{
    [Column("film_id")]
    public int FilmId { get; set; }
    public  Film Film { get; set; }
    
    [Column("genre_id")]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}