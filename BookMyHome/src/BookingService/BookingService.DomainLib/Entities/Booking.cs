using BookingService.DomainLib.Enums;
using BookingService.DomainLib.ValueObjects;
using BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.DomainLib.Entities;

/// <summary>
/// 
/// </summary>
public class Booking
{
    /// <summary>
    /// 
    /// </summary>
    public BookingId Id { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public int BookingNumber { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public BookingPeriod Period { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public BookingStatus Status { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public decimal Price { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public GuestId GuestId { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public AccomodationId AccomodationId { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public ListingId ListingId { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="guestId"></param>
    /// <param name="accomodationId"></param>
    /// <param name="listingId"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="price"></param>
    /// <returns></returns>
    /// <exception cref="DomainException"></exception>
    public static Booking Create(GuestId guestId, AccomodationId accomodationId, ListingId listingId, DateOnly startDate, DateOnly endDate, decimal price)
    {
        if (price < 0)
            throw new DomainException("price can not be less than 0");

        var bookingPeriod = new BookingPeriod(startDate, endDate);

        var booking = new Booking(guestId, accomodationId, listingId, bookingPeriod, price);

        return booking;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="DomainException"></exception>
    public void CancelBooking()
    {
        if (Status == BookingStatus.Cancelled)
            throw new DomainException("Booking is already cancelled");

        Status = BookingStatus.Cancelled;
    }

    private Booking(GuestId guestId, AccomodationId accomodationId, ListingId listingId, BookingPeriod bookingPeriod, decimal price)
    {
        Id = new BookingId(Guid.NewGuid());
        GuestId = guestId;
        AccomodationId = accomodationId;
        ListingId = listingId;
        Period = bookingPeriod;
        Price = price;
        Status = BookingStatus.Booked;
    }

    // EF Constructor
    private Booking() { }

}
