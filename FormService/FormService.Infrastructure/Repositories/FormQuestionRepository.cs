using FormService.Infrastructure.Context;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Infrastructure.Repositories;

public class FormQuestionRepository : Repository<FormQuestion>, IFormQuestionsRepository
{
    public FormQuestionRepository(AppDbContext context) : base(context)
    {
    }
}
