using AutoMapper;
using FormService.Domain.Dtos.FormQuestionDtos;
using FormService.Infrastructure.Context.Entities;

namespace FormService.Domain.Profiles;

public class FormQuestionDto : Profile
{
    public FormQuestionDto()
    {
        CreateMap<FormQuestion, GetFormQuestionDto>();
        CreateMap<CreateFormQuestionDto, FormQuestion>();
    }
}
