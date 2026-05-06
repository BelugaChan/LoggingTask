using LoggingTask.Application.Dto;
using LoggingTask.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoggingTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var res = await productService.GetByIdAsync(id, cancellationToken);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProductAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await productService.RemoveAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] RequestProductDto dto,
        CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        await productService.CreateAsync(dto, cancellationToken);
        return Ok();
    }

    [HttpPatch("updateProductName/{id}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid id, [FromBody] RequestUpdateProductDto dto,
        CancellationToken cancellationToken)
    {
        if(dto.Name is not null) await productService.UpdateProductNameAsync(id, dto.Name, cancellationToken);
        if(dto.Description is not null) await productService.UpdateProductDescriptionAsync(id, dto.Description, cancellationToken);
        if(dto.Price is not null) await productService.UpdateProductPriceAsync(id, dto.Price, cancellationToken);
        return Ok();
    }
}