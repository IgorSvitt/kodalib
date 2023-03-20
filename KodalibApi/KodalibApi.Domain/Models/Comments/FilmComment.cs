using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;

namespace KodalibApi.Data.Models.Comments;

[Table("film_comment")]
public class FilmComment
{
    [Column("film_id")]
    public int FilmId { get; set; }
    public Film Films { get; set; }

    [Column("comment_id")]
    public int CommentId { get; set; }
    public Comments Comments { get; set; }
}