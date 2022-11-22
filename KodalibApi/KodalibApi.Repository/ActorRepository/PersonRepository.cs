using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.ActorsTables;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Interfaces.ActorInterfaces;
using KodalibApi.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.ActorRepository;

public class PersonRepository: IActorRepository
{
    private readonly ApplicationDbContext _context;

    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(Person entity)
    {
        _context.Actors.Add(entity);
        Save();
    }
    
    public Person GetByName(string name)
    {
        return  _context.Actors.FirstOrDefault(x => x.Name == name);
    }

    public async Task<Person> GetById(int id)
    {
        return await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Person>> Select()
    {
        return await _context.Actors.ToListAsync();
    }

    public void Delete(Person entity)
    {
        _context.Actors.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task<PersonViewModel> GetByIdFullDescription(int id)
    {
        return await _context.Actors.Where(x => x.Id == id).Select(actor => new PersonViewModel()
        {
            Id = actor.Id,
            ImdbId = actor.PersonImdbId,
            Name = actor.Name,
            Role = actor.Role.Select(n => n.Role.Name).ToList(),
            Image = actor.Image,
            Summary = actor.Summary,
            BirthDate = actor.BirthDate,
            DeathDate = actor.DeathDate,
            Height = actor.Height,
            Films = actor.Films.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmId,
                Title = film.Film.Title,
            }).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<List<PersonViewModel>> GetAllActors()
    {
        return await _context.Actors.Select(actor => new PersonViewModel()
        {
            Id = actor.Id,
            ImdbId = actor.PersonImdbId,
            Name = actor.Name,
            Role = actor.Role.Select(n => n.Role.Name).ToList(),
            Image = actor.Image,
            Summary = actor.Summary,
            BirthDate = actor.BirthDate,
            DeathDate = actor.DeathDate,
            Height = actor.Height,
            Films = actor.Films.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmId,
                Title = film.Film.Title,
            }).ToList()
        }).ToListAsync();
    }

    public Person GetByImdbId(string imadbId)
    {
        return _context.Actors.FirstOrDefault(x => x.PersonImdbId == imadbId);
    }
    

    public async Task<PersonViewModel> GetByImdbIdFullDescription(string name)
    {
        return await _context.Actors.Where(x => x.Name == name).Select(actor => new PersonViewModel()
        {
            Id = actor.Id,
            ImdbId = actor.PersonImdbId,
            Name = actor.Name,
            Role = actor.Role.Select(n => n.Role.Name).ToList(),
            Image = actor.Image,
            Summary = actor.Summary,
            BirthDate = actor.BirthDate,
            DeathDate = actor.DeathDate,
            Height = actor.Height,
            Films = actor.Films.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmId,
                Title = film.Film.Title,
            }).ToList()
        }).FirstOrDefaultAsync();
    }
}