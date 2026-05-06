using AutoMapper;
using LoggingTask.Domain.Aggregates;
using LoggingTask.Domain.Converters.Factories;
using LoggingTask.Domain.Entities;

namespace LoggingTask.Domain.Converters.EntityToBusinessConverter;

public class EntityToBusinessProductProfile : Profile
{
    public EntityToBusinessProductProfile()
    {
        CreateMap<ProductEntity, ProductAggregate>().ConstructUsing<EntityToProductFactory>();
    }
}