using KodalibApi.Data.Context;
using KodalibApi.Data.Models.PeopleTables;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.Data.ViewModels.People;
using KodalibApi.Interfaces.RoleInterface;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.RoleRepository;

public class RoleRepository: IRoleRepository
{

    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Role entity)
    {
        _context.Roles.Add(entity);
        Save();
    }

    public async Task<Role> GetById(int id)
    {
        return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Role GetByName(string name)
    {
        return _context.Roles.FirstOrDefault(x => x.Name == name);
    }

    public async Task<List<Role>> Select()
    {
        return await _context.Roles.ToListAsync();
    }

    public void Delete(Role entity)
    {
        _context.Roles.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task<RoleViewModel> GetByNameFullDescription(string name)
    {
        return await _context.Roles.Where(x => x.Name == name).Select(role => new RoleViewModel()
        {
            Id = role.Id,
            Name = role.Name,
            PersonInfo = role.Persons.Select(person => new PersonIdAndNameViewModel()
            {
                Id = role.Id,
                Name = role.Name,
            }).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<RoleViewModel> GetByIdFullDescription(int id)
    {
        return await _context.Roles.Where(x => x.Id == id).Select(role => new RoleViewModel()
        {
            Id = role.Id,
            Name = role.Name,
            PersonInfo = role.Persons.Select(person => new PersonIdAndNameViewModel()
            {
                Id = role.Id,
                Name = role.Name,
            }).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<List<RoleViewModel>> GetAllGenres()
    {
        return await _context.Roles.Select(role => new RoleViewModel()
        {
            Id = role.Id,
            Name = role.Name,
            PersonInfo = role.Persons.Select(person => new PersonIdAndNameViewModel()
            {
                Id = role.Id,
                Name = role.Name,
            }).ToList()
        }).ToListAsync();
    }
}