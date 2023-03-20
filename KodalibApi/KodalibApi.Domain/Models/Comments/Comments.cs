using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.Comments;

[Table("comments")]
public class Comments
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("comment")]
    public string Comment { get; set; }
    
    [Column("rate")]
    public int Rate { get; set; }

    [Column("user")]
    public string User { get; set; }

    public List<FilmComment> FilmComments { get; set; }
    public List<SeriesComment> SeriesComments { get; set; }
}