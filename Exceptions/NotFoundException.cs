namespace WebApplication1.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
    
    public NotFoundException(string resourceName, int id) 
        : base($"{resourceName} with ID {id} was not found")
    {
    }
}
