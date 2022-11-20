using KodalibApi.Data.Models;

namespace KodalibApi.Data.ViewModels.Country;

public class CountryViewModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    
    public List<string>? FilmTitle { get; set; }
}