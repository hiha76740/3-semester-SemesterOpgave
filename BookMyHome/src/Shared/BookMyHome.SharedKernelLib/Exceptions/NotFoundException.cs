namespace BookMyHome.SharedKernelLib.Exceptions;

/// <summary>
/// 
/// </summary>
/// <param name="message"></param>
public class NotFoundException(string message) : Exception(message)
{
}
