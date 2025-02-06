using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.config;
using CallTrack.Share.Sort;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Data.repositories.Implementations;

public class GenericRepository<T> : IRepository<T> where T : class
{

    protected readonly CallTrackContext _context;

    public GenericRepository(CallTrackContext context)
    {
        _context = context;
    }

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

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
}
