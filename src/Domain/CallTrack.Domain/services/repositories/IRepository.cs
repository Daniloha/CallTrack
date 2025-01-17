using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Domain.services.repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    //Task<T?> GetAsync(long id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    T Delete(T entity);
}
