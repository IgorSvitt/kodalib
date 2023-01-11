using IMDbApiLib;
using IMDbApiLib.Models;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Country;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Genre;
using KodalibApi.DataInfill.Interfaces;

namespace KodalibApi.DataInfill.Implementations;

public class FilmDataInfill : IFilmDataInfill
{
    private readonly IFilmService _film;

    public FilmDataInfill(IFilmService film)
    {
        _film = film;
    }

    public void Create(List<string> id)
    {
        var apiLib = new ApiLib("k_sprfn59o");

        foreach (var filmId in id)
        {
            var data = apiLib.TitleAsync(filmId);
            var youtubeTrailer = apiLib.YouTubeTrailerAsync(filmId);
            var trailerImageUrl = apiLib.TrailerAsync(filmId);

            // var films = apiLib.AdvancedSearchAsync();

            var film = new FilmViewModels()
            {
                ImdbId = data.Result.Id,
                Title = data.Result.Title,
                Poster = data.Result.Image,
                Year = short.Parse(data.Result.Year),
                Duration = data.Result.RuntimeStr,
                Plot = data.Result.Plot,
                ImdbRating = data.Result.IMDbRating,
                Budget = data.Result.BoxOffice.Budget,
                GrossWorldwide = data.Result.BoxOffice.CumulativeWorldwideGross,
                YoutubeTrailer = youtubeTrailer.Result.VideoId,
                ThumbnailUrl = trailerImageUrl.Result.ThumbnailUrl,
                FilmsCountriesList = data.Result.CountryList.Select(country => new CountryViewModel()
                {
                    Name = country.Value
                }).ToList(),
                FilmsGenreList = data.Result.GenreList.Select(country => new GenreViewModel()
                {
                    Name = country.Value
                }).ToList(),
                ActorsList = data.Result.ActorList.Select(actor => new CharacterViewModel()
                {
                    Name = actor.Name,
                    ActorImdbId = actor.Id,
                    Role = actor.AsCharacter
                }).ToList(),
                TopActorsList = data.Result.StarList.Select(actor => new TopActorViewModel()
                {
                    Name = actor.Name,
                    ActorImdbId = actor.Id
                }).ToList(),
                WritersList = data.Result.WriterList.Select(writer => new WriterViewModel()
                {
                    Name = writer.Name,
                    WriterImdbId = writer.Id
                }).ToList(),
                DirectorList = data.Result.DirectorList.Select(director => new DirectorViewModel()
                {
                    Name = director.Name,
                    DirectorImdbId = director.Id
                }).ToList(),
            };

            _film.CreateFilmByImdbId(film);
        }
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}