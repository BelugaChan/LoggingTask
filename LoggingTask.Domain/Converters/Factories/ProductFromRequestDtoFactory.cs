using AutoMapper;
using LoggingTask.Domain.Aggregates;
using LoggingTask.Domain.Dto;

namespace LoggingTask.Domain.Converters.Factories;

public class ProductFromRequestDtoFactory : IDestinationFactory<RequestProductDto, ProductAggregate>
{
    public ProductAggregate Construct(RequestProductDto source, ResolutionContext context)
    {
        return new ProductAggregate(source.Name, source.Price, source.Description);
    }
}