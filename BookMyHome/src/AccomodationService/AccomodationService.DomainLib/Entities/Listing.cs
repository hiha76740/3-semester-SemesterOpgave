using AccomodationService.DomainLib.Enums;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.DomainLib.Entities;

public class Listing
{
    public ListingId Id { get; init; } = null!;

    public Accomodation Accomodation { get; init; } = null!;

    public string ListingName { get; private set; } = string.Empty;

    public decimal DailyPrice { get; private set; }

    public string HouseRules { get; private set; } = string.Empty;

    public AccomodationType Type { get; private set; }

    public ListingStatus Status { get; private set; }

    public string? ImageFileName { get; private set; }

    public byte[] RowVersion { get; private set; } = [];

    internal void SetImage(string imageFileName)
    {
        if (string.IsNullOrWhiteSpace(imageFileName))
            throw new DomainException("image file name must have a value");

        ImageFileName = imageFileName;
    }

    
    internal void UpdateStatus(ListingStatus newStatus)
    {
        if (Status == newStatus)
            throw new DomainException("Old and new status can not be the same");

        Status = newStatus;
    }

    internal void UpdateAccomodationType(AccomodationType newType)
    {
        if (Type == newType)
            throw new DomainException("Old and new type can not be the same");

        Type = newType;
    }

    internal void UpdateListingName(string newlistingName)
    {
        if (ListingName == newlistingName)
            throw new DomainException("Old and new name can not be the same");

        ListingName = newlistingName;
    }

    internal void UpdateDailyPrice(decimal newPrice)
    {
        if (newPrice == DailyPrice)
            throw new DomainException("Old and new price can not be the same");

        if (newPrice <= 0)
            throw new DomainException("new price can not be 0 or negative");

        DailyPrice = newPrice;
    }

    internal void UpdateHouseRules(string newHouseRules)
    {
        if (string.IsNullOrWhiteSpace(newHouseRules))
            throw new DomainException("new house rules can not be empty");

        HouseRules = newHouseRules;
    }

    internal Listing(Accomodation accomodation, string listingName, decimal dailyPrice, string houseRules, AccomodationType type)
    {
        if (string.IsNullOrWhiteSpace(listingName))
            throw new DomainException("listing name can not be empty");

        if (dailyPrice <= 0)
            throw new DomainException("Daily price can not be 0 or negative");

        if (string.IsNullOrWhiteSpace(houseRules))
            throw new DomainException("House rules can not be empty");

        Id = new ListingId(Guid.NewGuid());
        ListingName = listingName;
        DailyPrice = dailyPrice;
        HouseRules = houseRules;
        Type = type;
        Accomodation = accomodation;
        Status = ListingStatus.Active;
    }


    private Listing() { }
}
