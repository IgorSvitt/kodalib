﻿using Kodalib.Interfaces.GenreInterfaces;
using KodalibApi.Data.Context;
using KodalibApi.Data.Models;
using KodalibApi.Data.ViewModels.Genre;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.GenreRepository;

public class GenreRepository: IGenreRepository
{
    private readonly ApplicationDbContext _context;

    public GenreRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Genre entity)
    {
        _context.Genres.Add(entity);
        Save();
    }

    public async Task<Genre> Get(int id)
    {
        return await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Genre>> Select()
    {
        return await _context.Genres.ToListAsync();
    }

    public void Delete(Genre entity)
    {
        _context.Genres.Remove(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task<Genre> GetByName(string name)
    {
        return _context.Genres.FirstOrDefault(x => x.Name == name);
    }

    public async Task<GenreViewModel> GetById(int id)
    {
        return await _context.Genres.Where(x => x.Id == id).Select(country => new GenreViewModel()
        {
            Name = country.Name,
            FilmTitle = country.FilmsList.Select(n => n.Film.Title).ToList()
        }).FirstOrDefaultAsync();
    }

    public async Task<List<GenreViewModel>> GetAllCountry()
    {
        return await _context.Genres.Select(country => new GenreViewModel()
        {
            Name = country.Name,
            FilmTitle = country.FilmsList.Select(n => n.Film.Title).ToList()
        }).ToListAsync();
    }
}