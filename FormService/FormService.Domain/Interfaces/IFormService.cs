using FormService.Domain.Dtos.FormDtos;

namespace FormService.Domain.Interfaces;

public interface IFormService
{
    Task<IEnumerable<GetFormDto>> GetAllFormsAsync();
    Task<GetFormDto?> GetFormByIdAsync(int id);
    Task<bool> CreateFormAsync(CreateFormDto formDto);
    Task<bool> UpdateFormAsync(CreateFormDto formDto);
    Task<bool> DeleteFormAsync(int id); 
}
