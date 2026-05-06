using LoggingTask.Application.Dto;

namespace LoggingTask.Application.Interfaces;

public interface IProductService
{
    Task<ResponseProductDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task CreateAsync(RequestProductDto product, CancellationToken cancellationToken);
    
    Task UpdateProductNameAsync(Guid id, string newProductName, CancellationToken cancellationToken);
    
    Task UpdateProductDescriptionAsync(Guid id, string newProductDescription, CancellationToken cancellationToken);
    
    Task UpdateProductPriceAsync(Guid id, decimal newProductPrice, CancellationToken cancellationToken);
    
    Task RemoveAsync(Guid id, CancellationToken cancellationToken);
}