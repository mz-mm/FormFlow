using FormService.Infrastructure.Context;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormService.Infrastructure.Repositories;

public class FormQuestionRepository : Repository<FormQuestion>, IFormQuestionsRepository
{
    public FormQuestionRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<FormQuestion>> GetAllAsync(int formId)
    {
        return await Entities
            .Where(fq => fq.FormId == formId)
            .AsNoTracking()
            .ToListAsync();
    }
}
