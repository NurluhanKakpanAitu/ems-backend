namespace Application.Exception;

public class ApiException(string message) : System.Exception
{
    public sealed override string Message { get; } = message;
}