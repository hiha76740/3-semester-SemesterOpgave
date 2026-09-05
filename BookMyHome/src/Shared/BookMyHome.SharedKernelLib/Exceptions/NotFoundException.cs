namespace Shared.BookMyHome.SharedKernelLib.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}
