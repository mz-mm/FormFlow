using AutoMapper;
using FormService.Domain.Dtos.FormQuestionDtos;
using FormService.Domain.Exceptions;
using FormService.Domain.Interfaces;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Domain.Services;

public class FormQuestionService(IMapper mapper, IFormQuestionsRepository formQuestionsRepository, IFormService formService) : IFormQuestionService
{
    public async Task<IEnumerable<GetFormQuestionDto>> GetAllFormQuestionsAsync(int formId)
    {
        var formQuestions = (await formQuestionsRepository.GetAllAsync()).Where(fq => fq.FormId == formId);
        return mapper.Map<IEnumerable<GetFormQuestionDto>>(formQuestions);
    }

    public async Task<GetFormQuestionDto> CreateFormQuestionAsync(int formId, CreateFormQuestionDto formQuestionDto)
    {
        var form = await formService.GetFormByIdAsync(formId);

        if (form is null)
            throw new NotFoundException($"Form with ID {formId} not found");
        
        var formQuestionEntity = mapper.Map<FormQuestion>(formQuestionDto);
        var result = await formQuestionsRepository.InsertAsync(formQuestionEntity);

        return mapper.Map<GetFormQuestionDto>(formQuestionDto);
    }

    public async Task<bool> UpdateFormQuestionAsync(int formId, CreateFormQuestionDto formQuestionDto)
    {
        var form = await formService.GetFormByIdAsync(formId);
        
        if (form is null)
            throw new NotFoundException($"Form with ID {formId} not found");
        
        var formQuestionEntity = mapper.Map<FormQuestion>(formQuestionDto);
        var result = await formQuestionsRepository.UpdateAsync(formQuestionEntity);

        return result;
    }

    public async Task<bool> DeleteFormQuestionAsync(int id)
    {
        var formQuestion = await formQuestionsRepository.GetByIdAsync(id);
        
        if (formQuestion is null)
            return false;

        var result = await formQuestionsRepository.DeleteAsync(formQuestion);
        
        return result;
    } 
}
