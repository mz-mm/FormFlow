namespace FormService.Domain.Dtos.FormDtos;

public class GetFormDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsSubmissionOpen { get; set; }
    public int FormSubmissionLimit { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public int WorkspaceId { get; set; } 
}
