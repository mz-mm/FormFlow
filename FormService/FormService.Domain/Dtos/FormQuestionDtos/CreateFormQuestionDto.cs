namespace FormService.Domain.Dtos.FormQuestionDtos;

public class CreateFormQuestionDto
{
    public int FormId { get; set; }
    
    public string Question { get; set; }
    
    public string QuestionType { get; set; }
}