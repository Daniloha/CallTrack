using CallTrack.Domain.entities;
using CallTrack.Share.config;

namespace CallTrack.Domain.services.repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    //Task<T?> GetAsync(long id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    T Delete(T entity);
}
