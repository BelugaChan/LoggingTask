namespace LoggingTask.Domain;

public class EmptyProductNameException : Exception
{
    public EmptyProductNameException()
    {
        
    }

    public EmptyProductNameException(string message)
        : base(message)
    {
        
    }
}