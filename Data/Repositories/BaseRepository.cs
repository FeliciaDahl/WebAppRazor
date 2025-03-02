
using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{

    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task AddAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error occurred while creating {nameof(TEntity)} entity : {ex.Message}");

        }
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return predicate == null
            ? await _dbSet.ToListAsync()
            : await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public  void Update(TEntity entity)
    {
        try
        {
           _dbSet.Update(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error occurred while updating {nameof(TEntity)} entity : {ex.Message}");

        }
        
      
    }
    public void Delete(TEntity entity)
    {

        try
        {
            _dbSet.Remove(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error occurred while removing {nameof(TEntity)} entity : {ex.Message}");

        }
        
    }

    public async Task SaveAsync()
    {

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error occurred when saving {nameof(TEntity)} entity : {ex.Message}");

        }

        
    }
}
