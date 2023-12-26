namespace FormService.Domain.Dtos.FormQuestionDtos;

public class GetFormQuestionDto
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string Question { get; set; }
    public string QuestionType { get; set; }
    public DateTime CreatedAt { get; set; }
}
