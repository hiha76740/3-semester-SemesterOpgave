namespace BookMyHome.Web.States
{
    public class BookingState
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Guid AccomodationId { get; set; }
        public decimal DailyPrice {  get; set; }
        public decimal TotalPrice => (EndDate.DayOfYear - StartDate.DayOfYear) * DailyPrice;
    }
}
