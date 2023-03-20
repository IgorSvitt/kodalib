using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.Comments;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.FIlmTables;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Models.PeopleTables.SeriesPeople;

namespace KodalibApi.Data.Models.SeriesTable;

[Table("series")]
public class Series
{
    // Id of film
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    // IMDb Id of film
    [Column("kinopoisk_id")]
    public string? KinopoiskId { get; set; }

    // Title of film
    [Column("title")]
    public string Title { get; set; }

    // Link of poster by film
    [Column("poster")]
    public string? Poster { get; set; }

    // Year of film
    [Column("year")]
    public short? Year { get; set; }

    // Duration of film
    [Column("duration")]
    public string? Duration { get; set; }

    // Plot of film
    [Column("plot")]
    public string? Plot { get; set; }

    // IMDb rating of film
    [Column("kinopoisk_rating")]
    public string? KinopoiskRating { get; set; }
    
    // Kodalib rating of film
    [Column("kodalib_rating")]
    public string? KodalibRating { get; set; }

    [Column("count_rate")]
    public int CountRate { get; set; }

    // Link of Youtube Trailer by film 
    [Column("youtube_trailer")]
    public string? YoutubeTrailer { get; set; }

    // List of countries by film
    public List<SeriesCountries> Countries { get; set; } 
    
    // List of genres by film
    public List<SeriesGenres> Genres { get; set; }

    // List of characters by film
    public List<CharacterSeries> Characters { get; set; }

    public List<WriterSeries> Writers { get; set; }
    
    public List<DirectorSeries> Directors { get; set; }

    public List<SeriesVoiceover> Voiceovers { get; set; }
    
    public List<SeriesComment> Comments { get; set; }
}