namespace FormService.Infrastructure.Context.Entities;

public class Form : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsSubmissionOpen { get; set; }
    public int FormSubmissionLimit { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public int WorkspaceId { get; set; }
    
    public List<FormQuestion> FormQuestions { get; set; } 
}
