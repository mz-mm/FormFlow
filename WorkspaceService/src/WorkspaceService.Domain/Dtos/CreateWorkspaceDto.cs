using System.ComponentModel.DataAnnotations;

namespace WorkspaceService.Domain.Dtos;

public class CreateWorkspaceDto
{
    [Required(ErrorMessage = "Workspace Name is Required"), MinLength(3), MaxLength(30)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Workspace Description is Required")]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty; 
}
