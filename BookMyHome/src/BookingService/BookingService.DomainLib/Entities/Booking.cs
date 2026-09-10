using BookingService.DomainLib.Enums;
using BookingService.DomainLib.ValueObjects;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.DomainLib.Entities
{
    public class Booking
    {
        public BookingId Id { get; init; }
        public BookingPeriod Period { get; init; }
        public BookingStatus Status { get; private set; }
        public decimal Price { get; init; }

        public GuestId GuestId { get; init; }
        public AccomodationId AccomodationId { get; init; }

        public static Booking Create(GuestId guestId, AccomodationId accomodationId, DateOnly startDate, DateOnly endDate, decimal price, IEnumerable<Booking> existingBookings)
        {
            if (price < 0)
                throw new DomainException("price can not be less than 0");

            var bookingPeriod = new BookingPeriod(startDate, endDate);

            var booking = new Booking(guestId, accomodationId, bookingPeriod, price);

            ValidateOverlap(booking, existingBookings);

            return booking;
        }

        public void CancelBooking()
        {
            if (Status == BookingStatus.Cancelled)
                throw new DomainException("Booking is already cancelled");

            Status = BookingStatus.Cancelled;
        }


        private static void ValidateOverlap(Booking booking,IEnumerable<Booking> existingBookings)
        {
            var overlapFound = existingBookings.Any(eb =>
            eb.Id != booking.Id &&
            eb.AccomodationId == booking.AccomodationId &&
            eb.Status == BookingStatus.Booked &&
            booking.Period.StartDate < eb.Period.EndDate &&
            eb.Period.StartDate < booking.Period.EndDate
                );

            if (overlapFound == true)
                throw new DomainException("Can not create booking due to overlap");
        }

        private Booking(GuestId guestId, AccomodationId accomodationId, BookingPeriod bookingPeriod, decimal price)
        {
            Id = new BookingId(Guid.NewGuid());
            GuestId = guestId;
            AccomodationId = accomodationId;
            Period = bookingPeriod;
            Price = price;
            Status = BookingStatus.Booked;
        }

        // EF Constructor
        private Booking() { }

    }
}
