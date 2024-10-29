using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Data;
using TodoApp.Api.Interfaces.IRepositories;

namespace TodoApp.Api.Repositories;

public class BaseRepository<T>(TodoDbContext todoDbContext) : IBaseRepository<T>
    where T : class
{
    private DbSet<T> DbSet => todoDbContext.Set<T>();


    public async Task<IEnumerable<T>> GetAll()
    {
        var data = await DbSet
            .AsNoTracking()
            .ToListAsync();
        return data;
    }

    public async Task<T> GetById(int id)
    {
        var data = await DbSet.FindAsync(id);
        if (data == null)
        {
            throw new KeyNotFoundException("The item was not found");
        }
        return data;
    }

    public async Task<T> Create(T obj)
    {
        if (obj == null )
        {
            throw new ArgumentNullException(nameof(obj));
        }
        var addedObj = await DbSet.AddAsync(obj);
        await todoDbContext.SaveChangesAsync();
        return addedObj.Entity;
    }

    public async Task<T> Update(int id, T obj)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException("Entity not found.");
        }
        DbSet.Entry(entity).CurrentValues.SetValues(obj);
        await todoDbContext.SaveChangesAsync();
        
        return entity;
        
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await DbSet.FindAsync(id);
        
        if (entityToDelete == null)
        {
            throw new KeyNotFoundException("Entity not found.");
        }
        
        DbSet.Remove(entityToDelete);
        await todoDbContext.SaveChangesAsync();
        return true;

    }
    
}