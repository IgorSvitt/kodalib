using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.FilmTables;

[Table("films_genres")]
public class FilmsGenres
{
    [Column("films_id")]
    public int FilmsId { get; set; }
    
    public  Film Film { get; set; }
    
    [Column("genres_id")]
    public int GenreId { get; set; }
    
    public Genre Genre { get; set; }
}