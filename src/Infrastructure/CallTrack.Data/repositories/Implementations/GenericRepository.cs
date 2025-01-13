using CallTrack.Data;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.dtos.CallsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CallTrack.Data.repositories.Implementations;

public class GenericRepository<T> : IRepository<T> where T : class
{

    protected readonly CallTrackContext _context;

    public GenericRepository(CallTrackContext context)
    {
        _context = context;
    }
    //public async Task<T> CreateAsync(T entity)
    //{
    //    await _context.Set<T>().AddAsync(entity); // Adiciona a entidade de forma assíncrona
    //    await _context.SaveChangesAsync(); // Salva as mudanças de forma assíncrona
    //    return entity; // Retorna a entidade criada
    //}
    public async Task<T> CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }


    public T Delete(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    //public async Task<T?> GetAsync(long id)
    //{
    //    var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    //    return entity;
    //}

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
}
