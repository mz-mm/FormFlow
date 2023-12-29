using FormService.Infrastructure.Context.Entities;

namespace FormService.Infrastructure.Interfaces;

public interface IRepository<T> where T: BaseEntity
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(int id);
    public Task<bool> InsertAsync(T entity);
    public Task<bool> UpdateAsync(T entity);
    public Task<bool> DeleteAsync(T entity);
}
