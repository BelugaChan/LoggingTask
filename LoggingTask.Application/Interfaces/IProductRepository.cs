using LoggingTask.Domain.Aggregates;
using LoggingTask.Domain.Entities;

namespace LoggingTask.Application.Interfaces;

public interface IProductRepository
{
    Task<ProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<bool> CreateAsync(ProductEntity product, CancellationToken cancellationToken);

    Task<bool> UpdateAsync(Guid id, ProductEntity.UpdateAction<ProductAggregate> updateAction,
        CancellationToken cancellationToken);
    
    Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);
}