using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormService.Infrastructure.Context.Entities;

public class Form : BaseEntity
{
    public string FormName { get; set; }
    public string FormDescription { get; set; }
    public bool IsSubmissionOpen { get; set; }
    public int FormSubmissionLimit { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public int EventManagerId { get; set; }
    
    public List<FormQuestion> FormQuestions { get; set; } 
}
