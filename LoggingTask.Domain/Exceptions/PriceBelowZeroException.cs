namespace LoggingTask.Domain;

public class PriceBelowZeroException : Exception
{
    public PriceBelowZeroException()
    {
        
    }

    public PriceBelowZeroException(string message)
        : base(message)
    {
        
    }
}