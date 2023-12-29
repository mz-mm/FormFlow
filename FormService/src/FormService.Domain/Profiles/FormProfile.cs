using AutoMapper;
using FormService.Domain.Dtos.FormDtos;
using FormService.Infrastructure.Context.Entities;

namespace FormService.Domain.Profiles;

public class FormProfile : Profile
{
    public FormProfile()
    {
        CreateMap<Form, GetFormDto>();
        CreateMap<CreateFormDto, Form>();
    }
    
}
