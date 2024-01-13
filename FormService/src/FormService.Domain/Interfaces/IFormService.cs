using FormService.Domain.Dtos.FormDtos;
using FormService.Domain.Dtos.WorkspaceDtos;

namespace FormService.Domain.Interfaces;

public interface IFormService
{
    Task<IEnumerable<GetFormDto>> GetAllFormsAsync(int workspaceId);
    Task<GetFormDto?> GetFormByIdAsync(int formId);
    Task<GetFormDto> CreateFormAsync(int workspaceId, CreateFormDto formDto);
    Task<bool> UpdateFormAsync(int workspaceId, CreateFormDto formDto);
    Task<bool> DeleteFormAsync(int formId); 
}
