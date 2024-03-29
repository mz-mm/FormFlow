using FormService.Infrastructure.Context;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Infrastructure.Repositories;

public class FormRepository(AppDbContext context) : Repository<Form>(context), IFormRepository
{
}
