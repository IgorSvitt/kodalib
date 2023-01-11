using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.SeriesTable;

[Table("series_genres")]
public class SeriesGenres
{
    [Column("series_id")]
    public int SeriesId { get; set; }
    
    public  Series Series { get; set; }
    
    [Column("genres_id")]
    public int GenreId { get; set; }
    
    public Genre Genre { get; set; }
}