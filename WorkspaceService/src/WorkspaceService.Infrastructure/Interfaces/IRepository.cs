using WorkspaceService.Infrastructure.Contexts.Entities;

namespace WorkspaceService.Infrastructure.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int? id);
    Task<T> InsertAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);  
}
