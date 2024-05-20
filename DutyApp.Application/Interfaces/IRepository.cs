using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DutyApp.Application.Interfaces
{
  public interface IRepository<T> where T : class
  {
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity); // Update parameter type to T
  }
}