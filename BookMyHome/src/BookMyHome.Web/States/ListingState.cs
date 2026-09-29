namespace BookMyHome.Web.States
{
    public class ListingState
    {
        public string Name { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public void SetState(string listingName, string street, string postalCode, string city, string country, string type)
        {
            Name = listingName;
            Street = street;
            PostalCode = postalCode;
            City = city;
            Country = country;
            Type = type;
        }

        public void Clear()
        {
            Name = string.Empty;
            Street= string.Empty;
            PostalCode= string.Empty;
            City= string.Empty;
            Country= string.Empty;
            Type = string.Empty;
        }

    }
}
