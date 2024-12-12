using CallTrack.Data;
using CallTrack.Domain.services.repositories;
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
    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity); // Adiciona a entidade de forma assíncrona
        await _context.SaveChangesAsync(); // Salva as mudanças de forma assíncrona
        return entity; // Retorna a entidade criada
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

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(predicate);
        return entity;
    }

    public T Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }
}
