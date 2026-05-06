using LoggingTask.Domain.ValueObjects;

namespace LoggingTask.Domain.Aggregates;

public class ProductAggregate(string name, decimal initPrice, string description)
{
    public string Name { get; private set; } = name;

    public ProductPrice Price { get; private set; } = ProductPrice.CreateItem(initPrice);

    public string Description { get; private set; } = description;

    public void RenameProduct(string name) => Name = name;

    public void ChangeProductDescription(string description) => Description = description;

    public void ChangeProductPrice(decimal newPrice) => Price = ProductPrice.CreateItem(newPrice);
}