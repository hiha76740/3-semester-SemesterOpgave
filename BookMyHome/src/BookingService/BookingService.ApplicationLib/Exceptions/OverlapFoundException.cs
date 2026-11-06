namespace BookingService.ApplicationLib.Exceptions;

/// <summary>
/// 
/// </summary>
/// <param name="message"></param>
public class OverlapFoundException(string message) : Exception(message)
{
}
