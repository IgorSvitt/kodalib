using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Film;

namespace KodalibApi.Data.ViewModels.FilmCountry;

public class FilmsCountriesViewModel
{
    public CountryViewModel Country { get; set; }
    
    public  FilmViewModels Film { get; set; }
}