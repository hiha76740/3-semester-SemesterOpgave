namespace BookMyHome.Web.States
{
    public class BookingState
    {
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(7));
        public Guid AccomodationId { get; set; } = Guid.Empty;
        public decimal DailyPrice { get; set; } = 0;
        public decimal TotalPrice => (EndDate.DayOfYear - StartDate.DayOfYear) * DailyPrice;

        public void Clear()
        {
            StartDate = DateOnly.FromDateTime(DateTime.Today);
            EndDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7)); ;
            AccomodationId = Guid.Empty;
            DailyPrice = 0;
        }
    }
}
