using FormService.Domain.Dtos.FormQuestionDtos;

namespace FormService.Domain.Interfaces;

public interface IFormQuestionService
{
    Task<IEnumerable<GetFormQuestionDto>> GetAllFormQuestionsAsync(int formId);
    Task<bool> CreateFormQuestionAsync(CreateFormQuestionDto formQuestionDto);
    Task<bool> UpdateFormQuestionAsync(CreateFormQuestionDto formQuestion);
    Task<bool> DeleteFormQuestionAsync(int id); 

}
