using BookingService.FacadeLib.Commands.DTOs;

namespace BookingService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ICreateBookingHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(CreateBookingCommand command);
}
