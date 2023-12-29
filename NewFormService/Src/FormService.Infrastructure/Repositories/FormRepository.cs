using FormService.Infrastructure.Context;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Infrastructure.Repositories;

public class FormRepository : Repository<Form>, IFormRepository
{
    public FormRepository(AppDbContext context) : base(context)
    {
    }
}
