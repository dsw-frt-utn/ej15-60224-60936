namespace Dsw2026Ej15.Domain.Exceptions;

public class ValidationException : Exception
{
    //Constructor recibe error
    public ValidationException(string message) : base (message)
    {
    }
}

