using BookingService.FacadeLib.Commands.DTOs;

namespace BookingService.FacadeLib.Commands.Interfaces;

public interface ICancelBookingHandler
{
    Task Handle(CancelBookingCommand command);
}
