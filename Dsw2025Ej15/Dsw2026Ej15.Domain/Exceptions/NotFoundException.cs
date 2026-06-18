namespace Dsw2026Ej15.Domain.Exceptions;

public class NotFoundException : Exception
{
    //Constructor recibe error
    public NotFoundException(string message) : base (message)
    {
    }
}

