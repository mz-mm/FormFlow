namespace FormService.Infrastructure.Context.Entities;

public class Form : BaseEntity
{
    public int WorkspaceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsSubmissionOpen { get; set; } = true;
    public int FormSubmissionLimit { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Workspace Workspace { get; set; }
    public List<FormQuestion> FormQuestions { get; set; } 
}
