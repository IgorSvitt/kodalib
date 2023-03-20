using KodalibApi.Dal.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Data.ViewModels.Series;
using KodalibApi.Interfaces.Base;
using KodalibApi.Interfaces.PeopleInterface;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.ActorRepository;

public class PersonRepository : IPersonRepository
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

    public async Task<PersonViewModel> GetPersonById(int id, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .Where(x => x.Id == id)
            .Select(p => new PersonViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                KinopoiskId = p.PersonKinopoiskId,
                Films = p.Films.Select(f => new FilmTitleViewModel()
                {
                    Id = f.FilmId,
                    Title = f.Film.Title
                }).ToList(),
                Series = p.Series.Select(f => new SeriesTitleViewModel()
                {
                    Id = f.SeriesId,
                    Title = f.Series.Title
                }).ToList(),
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PersonViewModel?> GetPersonByName(string person, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .Where(x => x.Name == person)
            .Select(p => new PersonViewModel()
            {
                Id = p.Id
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel?> GetPersonIdByName(string person, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .Where(x => x.Name == person)
            .Select(p => new IdViewModel()
            {
                Id = p.Id
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel> CreatePerson(string person, CancellationToken cancellationToken)
    {
        var data = new Person()
        {
            Name = person,
        };

        await _context.Persons.AddAsync(data, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new IdViewModel() {Id = data.Id};
    }
}