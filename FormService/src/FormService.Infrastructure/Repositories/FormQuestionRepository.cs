using FormService.Infrastructure.Context;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormService.Infrastructure.Repositories;

public class FormQuestionRepository(AppDbContext context) : Repository<FormQuestion>(context), IFormQuestionsRepository
{
}
