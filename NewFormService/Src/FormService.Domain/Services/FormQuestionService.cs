using AutoMapper;
using FormService.Domain.Dtos.FormQuestionDtos;
using FormService.Domain.Interfaces;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Domain.Services;

public class FormQuestionService(IMapper mapper, IFormQuestionsRepository formQuestionsRepository) : IFormQuestionService
{
    public async Task<IEnumerable<GetFormQuestionDto>> GetAllFormQuestionsAsync(int formId)
    {
        var formQuestions = await formQuestionsRepository.GetAllAsync(formId);
        return mapper.Map<IEnumerable<GetFormQuestionDto>>(formQuestions);
    }

    public async Task<bool> CreateFormQuestionAsync(CreateFormQuestionDto formQuestionDto)
    {
        var formQuestionEntity = mapper.Map<FormQuestion>(formQuestionDto);
        var result = await formQuestionsRepository.InsertAsync(formQuestionEntity);

        return result;
    }

    public async Task<bool> UpdateFormQuestionAsync(CreateFormQuestionDto formQuestionDto)
    {
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
