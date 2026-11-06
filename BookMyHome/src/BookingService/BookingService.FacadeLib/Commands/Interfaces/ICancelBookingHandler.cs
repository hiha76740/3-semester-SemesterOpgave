using BookingService.FacadeLib.Commands.DTOs;

namespace BookingService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ICancelBookingHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task Handle(CancelBookingCommand command);
}
