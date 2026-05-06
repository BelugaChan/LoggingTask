using AutoMapper;
using LoggingTask.Domain.Aggregates;
using LoggingTask.Domain.Dto;

namespace LoggingTask.Domain.Converters.BusinessToDtoConverter;

public class BusinessToDtoProductProfile : Profile
{
    public BusinessToDtoProductProfile()
    {
        CreateMap<ProductAggregate, ResponseProductDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value));
    }
}