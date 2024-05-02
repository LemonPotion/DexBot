using Application.Dto_s.Person.Requests;
using Application.Dto_s.Person.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mapping;
/// <summary>
/// Конфигурация маппинга
/// </summary>
public class PersonMappingProfile : Profile
{
    
    public PersonMappingProfile()
    {
        //Requests
        
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

        CreateMap<GetPersonByIdRequest, Person>()
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
        
        
        //Responses
        CreateMap<Person,CreatePersonResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Telegram, opt => opt.MapFrom(src => src.Telegram))
            .ForMember(dest => dest.CustomFields, opt => opt.MapFrom(src => src.CustomFields));
        
        CreateMap<Person, GetPersonByIdResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<Person,UpdatePersonResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Telegram, opt => opt.MapFrom(src => src.Telegram))
            .ForMember(dest => dest.CustomFields, opt => opt.MapFrom(src => src.CustomFields));
    }
}