using AutoMapper;
using FormService.Domain.Dtos.FormDtos;
using FormService.Domain.Exceptions;
using FormService.Domain.Interfaces;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Domain.Services;

public class FormsService(IMapper mapper, IFormRepository formRepository, IWorkspaceService workspaceService) : IFormService
{
    public async Task<IEnumerable<GetFormDto>> GetAllFormsAsync(int workspaceId)
    {
        var forms = (await formRepository.GetAllAsync())
            .Where(forms => forms.WorkspaceId == workspaceId);

        return mapper.Map<IEnumerable<GetFormDto>>(forms);
    }

    public async Task<GetFormDto?> GetFormByIdAsync(int formId)
    {
        var form = await formRepository.GetByIdAsync(formId);
        
        return mapper.Map<GetFormDto>(form);
    }

    public async Task<GetFormDto> CreateFormAsync(int workspaceId, CreateFormDto formDto)
    {
        var workspacesExist = await workspaceService.WorkspacesExistAsync(workspaceId);

        if (!workspacesExist)
            throw new NotFoundException($"Form with ID {workspaceId} not found");
 
        var formEntity = mapper.Map<Form>(formDto);
        formEntity.WorkspaceId = workspaceId;
        
        var result = await formRepository.InsertAsync(formEntity);

        return mapper.Map<GetFormDto>(result);
    }

    public async Task<bool> UpdateFormAsync(int workspaceId, CreateFormDto formDto)
    {
        var formEntity = mapper.Map<Form>(formDto);
        formEntity.WorkspaceId = workspaceId;
        var result = await formRepository.UpdateAsync(formEntity);

        return result;
    }

    public async Task<bool> DeleteFormAsync(int formId)
    {
        var form = await formRepository.GetByIdAsync(formId);

        if (form is null)
            return false;

        var result = await formRepository.DeleteAsync(form);

        return result;
    }
}
