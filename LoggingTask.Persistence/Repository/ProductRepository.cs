using AutoMapper;
using LoggingTask.Application.Interfaces;
using LoggingTask.Domain.Aggregates;
using LoggingTask.Domain.Entities;
using LoggingTask.Persistence.Context;

namespace LoggingTask.Persistence.Repository;

public class ProductRepository(MyDbContext context, IMapper mapper) : IProductRepository
{
    public async Task<ProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await context.Products.FindAsync([id], cancellationToken);

    public async Task<bool> CreateAsync(ProductEntity product, CancellationToken cancellationToken)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, ProductEntity.UpdateAction<ProductAggregate> updateAction, 
        CancellationToken cancellationToken)
    {
        var entity = context.Products.FindAsync([id], cancellationToken);
        var productBusinessModel = mapper.Map<ProductAggregate>(entity);
        updateAction(productBusinessModel);
        var updatedEntity = mapper.Map<ProductEntity>(productBusinessModel);
        context.Products.Update(updatedEntity);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync([id], cancellationToken: cancellationToken);
        context.Products.Remove(product);
        return true;
    }
}