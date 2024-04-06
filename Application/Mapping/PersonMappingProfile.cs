using AutoMapper;
using ClassLibrary1.Dto_s.Person.Requests;
using Domain.Entities;
using Domain.ValueObjects;

namespace ClassLibrary1.Mapping;
/// <summary>
/// Конфигурация маппинга
/// </summary>
//TODO: Добавить маппинг для response`ов 
public class PersonMappingProfile : Profile
{
    
    public PersonMappingProfile()
    {
        CreateMap<CreatePersonRequest, Person>()
            .ConstructUsing(dto => new Person(
                Guid.NewGuid(),
                new FullName(dto.FullName.FirstName, dto.FullName.LastName, dto.FullName.MiddleName),
                dto.Gender,
                dto.BirthDay,
                dto.PhoneNumber,
                dto.Telegram,
                dto.CustomFields
            ));

        CreateMap<GetPersonRequest, Person>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<UpdatePersonRequest, Person>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Telegram, opt => opt.MapFrom(src => src.Telegram))
            .ForMember(dest => dest.CustomFields, opt => opt.MapFrom(src => src.CustomFields));

        CreateMap<DeletePersonRequest, Person>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}