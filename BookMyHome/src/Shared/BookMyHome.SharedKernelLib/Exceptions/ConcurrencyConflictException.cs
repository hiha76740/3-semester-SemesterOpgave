namespace BookMyHome.SharedKernelLib.Exceptions;

/// <summary>
/// 
/// </summary>
/// <param name="message"></param>
/// <param name="innerException"></param>
public class ConcurrencyConflictException(string message, Exception innerException) : Exception(message, innerException)
{
}
