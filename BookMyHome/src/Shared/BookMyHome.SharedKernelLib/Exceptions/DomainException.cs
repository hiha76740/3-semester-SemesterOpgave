namespace Shared.BookMyHome.SharedKernelLib.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
}
