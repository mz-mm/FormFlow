using System.ComponentModel.DataAnnotations;

namespace FormService.Domain.Dtos.FormQuestionDtos;

public class CreateFormQuestionDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(120)]
    public string Question { get; set; }
    
    [Required]
    public string QuestionType { get; set; }
}
