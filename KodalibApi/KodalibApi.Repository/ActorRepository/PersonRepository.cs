using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Interfaces.Base;
using KodalibApi.Interfaces.PeopleInterface;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.ActorRepository;

public class PersonRepository: IPersonRepository
{
    private readonly ApplicationDbContext _context;

    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(Person entity)
    {
        _context.Persons.Add(entity);
        Save();
    }
    
    public Person GetByName(string name)
    {
        return  _context.Persons.FirstOrDefault(x => x.Name == name);
    }

    public async Task<Person> GetById(int id)
    {
        return await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Person>> Select()
    {
        return await _context.Persons.ToListAsync();
    }

    public void Delete(Person entity)
    {
        _context.Persons.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Person entity)
    {
        _context.Persons.Update(entity);
        Save();
    }

    public async Task<PersonViewModel> GetByIdFullDescription(int id)
    {
        return await _context.Persons.Where(x => x.Id == id).Select(person => new PersonViewModel()
        {
            Id = person.Id,
            KinopoiskId = person.PersonKinopoiskId,
            Name = person.Name,
            Role = person.Role.Select(n => n.Role.Name).ToList(),
            Image = person.Image,
            Summary = person.Summary,
            BirthDate = person.BirthDate,
            DeathDate = person.DeathDate,
            Films = person.Films.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmId,
                Title = film.Film.Title,
            }).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<List<PersonViewModel>> GetAllPeople()
    {
        return await _context.Persons.Select(person => new PersonViewModel()
        {
            Id = person.Id,
            KinopoiskId = person.PersonKinopoiskId,
            Name = person.Name,
            Role = person.Role.Select(n => n.Role.Name).ToList(),
            Image = person.Image,
            Summary = person.Summary,
            BirthDate = person.BirthDate,
            DeathDate = person.DeathDate,
            Films = person.Films.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmId,
                Title = film.Film.Title,
            }).ToList()
        }).ToListAsync();
    }

    public Person GetByImdbId(string imadbId)
    {
        return _context.Persons.FirstOrDefault(x => x.PersonKinopoiskId == imadbId);
    }
    

    public async Task<PersonViewModel> GetByImdbIdFullDescription(string name)
    {
        return await _context.Persons.Where(x => x.Name == name).Select(person => new PersonViewModel()
        {
            Id = person.Id,
            KinopoiskId = person.PersonKinopoiskId,
            Name = person.Name,
            Role = person.Role.Select(n => n.Role.Name).ToList(),
            Image = person.Image,
            Summary = person.Summary,
            BirthDate = person.BirthDate,
            DeathDate = person.DeathDate,
            Films = person.Films.Select(film => new FilmIdAndTitleViewModel()
            {
                Id = film.FilmId,
                Title = film.Film.Title,
            }).ToList()
        }).FirstOrDefaultAsync();
    }
}