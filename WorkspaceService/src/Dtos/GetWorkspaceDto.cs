namespace src.Dtos;

public class GetWorkspaceDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; 
    public DateTime CreatedAt { get; set; }
}
