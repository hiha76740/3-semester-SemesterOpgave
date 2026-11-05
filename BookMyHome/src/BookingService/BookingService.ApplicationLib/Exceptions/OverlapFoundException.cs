namespace BookingService.ApplicationLib.Exceptions;

internal class OverlapFoundException : Exception
{
    public OverlapFoundException(string message) : base(message) { }
}
