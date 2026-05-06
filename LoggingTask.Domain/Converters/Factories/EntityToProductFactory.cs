using AutoMapper;
using LoggingTask.Domain.Aggregates;
using LoggingTask.Domain.Entities;

namespace LoggingTask.Domain.Converters.Factories;

public class EntityToProductFactory : IDestinationFactory<ProductEntity, ProductAggregate>
{
    public ProductAggregate Construct(ProductEntity source, ResolutionContext context)
    {
        return new ProductAggregate(source.Name, source.Price, source.Description);
    }
}