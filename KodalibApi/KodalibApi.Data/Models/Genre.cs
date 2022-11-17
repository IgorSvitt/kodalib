﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KodalibApi.Data.Models.FilmTables;

namespace KodalibApi.Data.Models;

[Table("genres")]
public class Genre
{
    // Id of genre
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    // Name of genre
    [Column("name")]
    public string Name { get; set; }

    public List<FilmsGenres>? FilmsList { get; set; }
}