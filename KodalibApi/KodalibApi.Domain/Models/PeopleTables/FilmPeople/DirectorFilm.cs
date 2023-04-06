using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.PeopleTables;

[Table("directors_films")]
public class DirectorFilm
{
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("director_id")]
    public int DirectorId { get; set; }

    public Person Director { get; set; }

    public Film Film { get; set; }
}