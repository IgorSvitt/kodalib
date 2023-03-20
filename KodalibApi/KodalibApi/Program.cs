using Kodalib.Repository.ActorRepository;
using KodalibApi.Interfaces.CountryInterfaces;
using KodalibApi.Interfaces.FilmIntefaces;
using KodalibApi.Interfaces.GenreInterfaces;
using Kodalib.Repository.CountryRepository;
using Kodalib.Repository.FilmRepository;
using Kodalib.Repository.GenreRepository;
using Kodalib.Repository.SeriesRepository;
using Kodalib.Repository.VoiceoverRepository;
using Kodalib.Service.Implementations;
using Kodalib.Service.Interfaces;
using KodalibApi.Dal.Context;
using KodalibApi.Interfaces;
using KodalibApi.Interfaces.PeopleInterface;
using KodalibApi.Interfaces.Voiceover;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors();

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IFilmService, FilmService>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();
builder.Services.AddScoped<ISeriesService, SeriesService>();

builder.Services.AddScoped<IVoiceoverRepository, VoiceoverRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();