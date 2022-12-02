using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.PeopleTables;

namespace KodalibApi.Data.Models.FIlmTables;


[Table("films")]
public class Film
{
    // Id of film
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    // IMDb Id of film
    [Column("imdb_id")]
    public string ImdbId { get; set; }

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
    [Column("imdb_rating")]
    public string? ImdbRating { get; set; }
    
    // Kodalib rating of film
    [Column("kodalib_rating")]
    public string? KodalibRating { get; set; }

    // Budget of film
    [Column("budget")]
    public string? Budget { get; set; }

    // Gross worldwide of film
    [Column("gross_worldwide")]
    public string? GrossWorldwide { get; set; }

    // Link of Youtube Trailer by film 
    [Column("youtube_trailer")]
    public string? YoutubeTrailer { get; set; }
    
    [Column("ThumbnailUrl")]
    public string? ThumbnailUrl { get; set; }
    
    // List of countries by film
    public List<FilmsCountries>? CountriesList { get; set; } 
    
    // List of genres by film
    public List<FilmsGenres>? GenresList { get; set; }
    
    // List of actors by film
    public List<TopActor>? TopActors { get; set; }

    // List of characters by film
    public List<Character>? Characters { get; set; }

    public List<Writers> WritersList { get; set; }
    
    public List<Director> DirectorsList { get; set; }
}