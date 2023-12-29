using AutoMapper;
using FormService.Domain.Dtos.FormDtos;
using FormService.Domain.Interfaces;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Domain.Services;

public class FormsService(IMapper mapper, IFormRepository formRepository) : IFormService
{
    public async Task<IEnumerable<GetFormDto>> GetAllFormsAsync()
    {
        var forms = await formRepository.GetAllAsync();
        return mapper.Map<IEnumerable<GetFormDto>>(forms);
    }

    public async Task<GetFormDto?> GetFormByIdAsync(int id)
    {
        var form = await formRepository.GetByIdAsync(id);
        return mapper.Map<GetFormDto>(form);
    }

    public async Task<bool> CreateFormAsync(CreateFormDto formDto)
    {
        var formEntity = mapper.Map<Form>(formDto);
        var result = await formRepository.InsertAsync(formEntity);

        return result;
    }

    public async Task<bool> UpdateFormAsync(CreateFormDto formDto)
    {
        var formEntity = mapper.Map<Form>(formDto);
        var result = await formRepository.UpdateAsync(formEntity);

        return result;
    }

    public async Task<bool> DeleteFormAsync(int id)
    {
        var form = await formRepository.GetByIdAsync(id);
        
        if (form is null)
            return false;

        var result = await formRepository.DeleteAsync(form);
        
        return result;
    }
}
