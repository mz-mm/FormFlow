namespace FormService.Infrastructure.Context.Entities;

public class Workspace : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Form> Forms { get; set; }
}
