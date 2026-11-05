namespace BookMyHome.Web.Models
{
    public class BookingInputModel
    {
        public Guid GuestId { get; set; }
        public Guid AccomodationId { get; set; }
        public Guid ListingId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
