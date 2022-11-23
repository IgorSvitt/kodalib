using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.PeopleTables;

[Table("writers_films")]
public class WritersFilms
{
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("writer_id")]
    public int WriterId { get; set; }

    public Person Writer { get; set; }

    public Film Film { get; set; }
}