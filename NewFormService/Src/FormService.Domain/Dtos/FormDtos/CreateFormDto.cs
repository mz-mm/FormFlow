using System.ComponentModel.DataAnnotations;

namespace FormService.Domain.Dtos.FormDtos;

public class CreateFormDto
{
    [Required(ErrorMessage = "Event Id is Required")]
    public int EventId { get; set; }
    
    [Required(ErrorMessage = "Workspace Name is Required"), MinLength(3), MaxLength(30)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Workspace Description is Required")]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    public bool IsSubmissionOpen { get; set; }
    
    public bool FormSubmissionLimit { get; set; }
    
    public DateTime StartDatetime { get; set; }
    
    public DateTime EndDatetime { get; set; }
}
