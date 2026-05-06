using AutoMapper;
using LoggingTask.Domain.Aggregates;
using LoggingTask.Domain.Converters.Factories;
using LoggingTask.Domain.Dto;

namespace LoggingTask.Domain.Converters.DtoToBusinessConverter;

public class DtoToBusinessProductProfile : Profile
{
    public DtoToBusinessProductProfile()
    {
        CreateMap<RequestProductDto, ProductAggregate>().ConstructUsing<ProductFromRequestDtoFactory>();
    }
}