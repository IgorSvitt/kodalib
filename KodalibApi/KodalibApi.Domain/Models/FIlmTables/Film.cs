﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.Comments;
using KodalibApi.Data.Models.FilmTables;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.Models.PeopleTables.FilmPeople;

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
    public List<FilmCountry>? CountriesList { get; set; } 
    
    // List of genres by film
    public List<FilmGenre>? GenresList { get; set; }

    // List of characters by film
    public List<Character>? Characters { get; set; }

    public List<Writer>? Writers { get; set; }
    
    public List<Director>? Directors { get; set; }

    public List<FilmVoiceover>? Voiceovers { get; set; }
    
    public List<FilmComment>? Comments { get; set; }

}