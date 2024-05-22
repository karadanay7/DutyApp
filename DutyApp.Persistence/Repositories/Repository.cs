﻿using DutyApp.Application;
using Microsoft.EntityFrameworkCore;

namespace DutyApp.Persistence;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DutyAppDbContext _context;
    private readonly DbSet<T> _dbSet;
    public Repository(DutyAppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
    

}
