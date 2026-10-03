namespace BookMyHome.Web.Models
{
    public class AccomodationInputModel
    {
        public Guid AccomodationId { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public List<Guid> FacilitiesIds { get; set; } = [];
    }
}
