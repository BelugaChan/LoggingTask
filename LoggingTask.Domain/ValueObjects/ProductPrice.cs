namespace LoggingTask.Domain.ValueObjects;

public class ProductPrice
{
    public decimal Value { get; }

    private ProductPrice(decimal value)
        => Value = value;

    public static ProductPrice CreateItem(decimal price)
    {
        if(price < 0) throw new PriceBelowZeroException();
        
        return new ProductPrice(price);
    }
}