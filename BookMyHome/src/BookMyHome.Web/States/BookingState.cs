namespace BookMyHome.Web.States
{
    public class BookingState
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Guid AccomodationId { get; set; }
        public Guid TotalPrice { get; set; }
    }
}
