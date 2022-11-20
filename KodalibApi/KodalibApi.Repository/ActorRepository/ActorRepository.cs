using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Interfaces.ActorInterfaces;
using KodalibApi.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.ActorRepository;

public class ActorRepository: IActorRepository
{
    private readonly ApplicationDbContext _context;

    public ActorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(Actor entity)
    {
        _context.Actors.Add(entity);
        Save();
    }
    
    public Actor GetByName(string name)
    {
        return  _context.Actors.FirstOrDefault(x => x.Name == name);
    }

    public async Task<Actor> GetById(int id)
    {
        return await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Actor>> Select()
    {
        return await _context.Actors.ToListAsync();
    }

    public void Delete(Actor entity)
    {
        _context.Actors.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task<ActorViewModel> GetByIdFullDescription(int id)
    {
        return await _context.Actors.Where(x => x.Id == id).Select(actor => new ActorViewModel()
        {
            Id = actor.Id,
            ImdbId = actor.ActorImdbId,
            Name = actor.Name,
            Role = actor.Role,
            Image = actor.Image,
            Summary = actor.Summary,
            BirthDate = actor.BirthDate,
            DeathDate = actor.DeathDate,
            Height = actor.Height,
            Films = actor.Films.Select(n=>n.Film.Title).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<List<ActorViewModel>> GetAllActors()
    {
        return await _context.Actors.Select(actor => new ActorViewModel()
        {
            Id = actor.Id,
            ImdbId = actor.ActorImdbId,
            Name = actor.Name,
            Role = actor.Role,
            Image = actor.Image,
            Summary = actor.Summary,
            BirthDate = actor.BirthDate,
            DeathDate = actor.DeathDate,
            Height = actor.Height,
            Films = actor.Films.Select(n=>n.Film.Title).ToList()
        }).ToListAsync();
    }

    public async Task<Actor> GetByImdbId(string imadbId)
    {
        return await _context.Actors.FirstOrDefaultAsync(x => x.ActorImdbId == imadbId);
    }
    

    public async Task<ActorViewModel> GetByImdbIdFullDescription(string name)
    {
        return await _context.Actors.Where(x => x.Name == name).Select(actor => new ActorViewModel()
        {
            Id = actor.Id,
            ImdbId = actor.ActorImdbId,
            Name = actor.Name,
            Role = actor.Role,
            Image = actor.Image,
            Summary = actor.Summary,
            BirthDate = actor.BirthDate,
            DeathDate = actor.DeathDate,
            Height = actor.Height,
            Films = actor.Films.Select(n=>n.Film.Title).ToList()
        }).FirstOrDefaultAsync();
    }
}