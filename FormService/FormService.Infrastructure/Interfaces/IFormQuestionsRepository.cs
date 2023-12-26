using FormService.Infrastructure.Context.Entities;

namespace FormService.Infrastructure.Interfaces;

public interface IFormQuestionsRepository : IRepository<FormQuestion>
{
    public Task<IEnumerable<FormQuestion>> GetAllAsync(int formId);
}
