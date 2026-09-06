using BookingService.FacadeLib.Commands.DTOs;

namespace BookingService.ApplicationLib.Handlers
{
    public interface ICancelBookingHandler
    {
        Task Handle(CancelBookingCommand command);
    }
}