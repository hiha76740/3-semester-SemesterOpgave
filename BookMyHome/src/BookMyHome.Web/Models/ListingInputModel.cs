namespace BookMyHome.Web.Models
{
    public class ListingInputModel
    {
        public string ListingName { get; set; } = string.Empty;
        public Guid AccomodationId { get; set; } = Guid.Empty;
        public decimal DailyPrice { get; set; } = 0;
        public string HouseRules { get; set; } = string.Empty;
        public string AccomodationType { get; set; } = string.Empty;

    }
}
