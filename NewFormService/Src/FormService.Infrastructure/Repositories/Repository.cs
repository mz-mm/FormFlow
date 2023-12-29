using FormService.Infrastructure.Context;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormService.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T: BaseEntity
{
    private readonly AppDbContext _context;
    protected readonly DbSet<T> Entities;

    protected Repository(AppDbContext context)
    {
        _context = context;
        Entities = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await Entities.AsNoTracking().ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id) =>
        await Entities.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

    public virtual async Task<bool> InsertAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await Entities.AddAsync(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        Entities.Update(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        Entities.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    } 
}
