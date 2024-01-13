using FormService.Domain.Dtos.FormQuestionDtos;

namespace FormService.Domain.Interfaces;

public interface IFormQuestionService
{
    Task<IEnumerable<GetFormQuestionDto>> GetAllFormQuestionsAsync(int formId);
    Task<GetFormQuestionDto> CreateFormQuestionAsync(int formId, CreateFormQuestionDto formQuestionDto);
    Task<bool> UpdateFormQuestionAsync(int formId, CreateFormQuestionDto formQuestion);
    Task<bool> DeleteFormQuestionAsync(int id); 

}
