using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KodalibApi.Data.Models.SeriesTable;

[Table("season")]
public class Season
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("number_season")]
    public short NumberSeason { get; set; }
    
    [Column("series_id")]
    public int SeriesId { get; set; }
    public Series Series { get; set; }

    public List<Episodes> Episodes { get; set; }
}