using AutoMapper;
using Georeferenciamento.Application.DTOs;
using Georeferenciamento.Application.Handlers.CreateState;
using Georeferenciamento.Application.Handlers.GetCitie;
using Georeferenciamento.Application.Handlers.GetState;
using Georeferenciamento.Domain.Entities;

namespace Georeferenciamento.Application.Mappers;

public class StateProfile : Profile
{
    public StateProfile()
    {
        _ = CreateMap<CreateStateCommand, State>()
            .ForMember(dest => dest.StatePostalCode, opt => opt.MapFrom(src => src.StatePostalCode))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Capital, opt => opt.MapFrom(src => src.Capital))
            .ForMember(dest => dest.Cities, opt => opt.Ignore());
        
        _ = CreateMap<CityDto, Cities>()
            .ConstructUsing(src => new Cities(src.City!, src.Longitude, src.Latitude));

        _ = CreateMap<Cities, CityDto>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude));
        
        _ = CreateMap<State, GetStateResult>()
            .ForMember(dest => dest.StatePostalCode, opt => opt.MapFrom(src => src.StatePostalCode))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Capital, opt => opt.MapFrom(src => src.Capital))
            .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities));
        
        _ = CreateMap<Cities, GetCitiesResult>()
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
            .ForMember(dest => dest.StatePostalCode, opt => opt.MapFrom(src => src.StatePostalCode));
    }
}