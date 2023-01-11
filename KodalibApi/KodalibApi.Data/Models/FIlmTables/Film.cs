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
    [Column("kinopoisk_id")]
    public string? KinopoiskId { get; set; }

    // Title of film
    [Column("title")]
    public string Title { get; set; }
    
    [Column("org_title")]
    public string? OriginalTitle { get; set; }
    
    [Column("link_video")] 
    public string LinkVideo { get; set; }

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