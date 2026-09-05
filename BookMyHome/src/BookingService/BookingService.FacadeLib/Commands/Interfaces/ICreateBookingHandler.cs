using BookingService.FacadeLib.Commands.DTOs;

namespace BookingService.FacadeLib.Commands.Interfaces;

public interface ICreateBookingHandler
{
    Task Handle(CreateBookingCommand command);
}
