using AutoMapper;
using LoggingTask.Domain.Aggregates;
using LoggingTask.Domain.Dto;
using LoggingTask.Domain.Entities;

namespace LoggingTask.Domain.Converters.BusinessToEntityConverter;

public class BusinessToEntityProductProfile : Profile
{
    public BusinessToEntityProductProfile()
    {
        CreateMap<ProductAggregate, ProductEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value));
    }
}