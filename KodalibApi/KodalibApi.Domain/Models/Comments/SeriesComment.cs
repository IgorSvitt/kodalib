using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.SeriesTable;

namespace KodalibApi.Data.Models.Comments;

[Table("series_comment")]
public class SeriesComment
{
    [Column("film_id")]
    public int SeriesId { get; set; }
    public Series Series { get; set; }

    [Column("comment_id")]
    public int CommentId { get; set; }
    public Comments Comments { get; set; }
}