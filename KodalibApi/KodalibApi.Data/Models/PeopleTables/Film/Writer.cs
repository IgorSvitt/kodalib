using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.PeopleTables;

[Table("writers_films")]
public class Writers
{
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("writer_id")]
    public int WriterId { get; set; }

    public Person WriterPerson { get; set; }

    public Film Film { get; set; }
}