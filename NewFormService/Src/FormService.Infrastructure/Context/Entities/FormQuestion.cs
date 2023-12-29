namespace FormService.Infrastructure.Context.Entities;

public class FormQuestion : BaseEntity
{
    public string Question { get; set; }
    public string QuestionType { get; set; }
    public DateTime CreatedAt { get; set; }
    public int FormId { get; set; }
    public Form Form { get; set; } 
}
