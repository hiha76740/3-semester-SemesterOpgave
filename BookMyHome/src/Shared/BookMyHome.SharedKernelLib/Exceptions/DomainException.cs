namespace BookMyHome.SharedKernelLib.Exceptions;

/// <summary>
/// 
/// </summary>
/// <param name="message"></param>
public class DomainException(string message) : Exception(message)
{
}
