namespace WorkspaceService.Infrastructure.Contexts.Entities;

public class Workspace : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
