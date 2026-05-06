using AutoMapper;
using LoggingTask.Application.Dto;
using LoggingTask.Application.Interfaces;
using LoggingTask.Domain.Entities;

namespace LoggingTask.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    public async Task<ResponseProductDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await productRepository.GetByIdAsync(id, cancellationToken);
        return mapper.Map<ResponseProductDto>(entity);
    }

    public async Task<bool> CreateAsync(RequestProductDto product, CancellationToken cancellationToken)
    {
        var productEntity = mapper.Map<ProductEntity>(product);
        return await productRepository.CreateAsync(productEntity, cancellationToken);
    }

    public async Task<bool> UpdateProductNameAsync(Guid id, string newProductName, CancellationToken cancellationToken)
    {
        return await productRepository.UpdateAsync(id, product =>
        {
            product.RenameProduct(newProductName);
        },  cancellationToken);
    }

    public async Task<bool> UpdateProductDescriptionAsync(Guid id, string newProductDescription, CancellationToken cancellationToken)
    {
        return await productRepository.UpdateAsync(id, product =>
        {
            product.ChangeProductDescription(newProductDescription);
        },  cancellationToken);
    }

    public async Task<bool> UpdateProductPriceAsync(Guid id, decimal newProductPrice, CancellationToken cancellationToken)
    {
        return await productRepository.UpdateAsync(id, product =>
        {
            product.ChangeProductPrice(newProductPrice);
        },  cancellationToken);
    }

    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken) 
        => await productRepository.RemoveAsync(id, cancellationToken);
}