using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.DomainLib.Entities;

public class Accomodation
{
    public AccomodationId Id { get; init; } = null!;
    public string Title { get; init; } = null!;
    public HostId HostId { get; init; } = null!;
    public AccomodationStatus Status { get; private set; }

    private readonly List<Listing> _listings = [];
    public IReadOnlyList<Listing> listings => _listings.AsReadOnly();


    public void CreateListing(string listingName, decimal dailyPrice, string houseRules, AccomodationType type)
    {
        var listing = new Listing(this.Id, listingName, dailyPrice, houseRules, type);

        _listings.Add(listing);
    }

    public void RemoveListing(Guid id)
    {
        var listingId = new ListingId(id);

        var listing = GetListing(listingId);

        _listings.Remove(listing);
    }

    public void UpdateListingDailyPrice(Guid id, decimal newPrice)
    {
        var listingId = new ListingId(id);

        var listing = GetListing(listingId);

        listing.UpdateDailyPrice(newPrice);
    }

    public void UpdateHouseRules(Guid id, string newHouseRules)
    {
        var listingId = new ListingId(id);

        var listing = GetListing(listingId);

        listing.UpdateHouseRules(newHouseRules);
    }

    private Listing GetListing(ListingId id)
    {
        var listing = _listings.FirstOrDefault(l => l.Id == id);

        if (listing == null)
            throw new DomainException("No losting was found");

        return listing;
    }


    public static Accomodation Create(HostId hostId, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title can not be empty");

        var accomodation = new Accomodation(hostId, title);

        return accomodation;
    }

    private Accomodation(HostId hostId, string title)
    {
        Id = new AccomodationId(Guid.NewGuid());
        Title = title;
        HostId = hostId;
        Status = AccomodationStatus.Active;
    }

    // EF constructor
    private Accomodation() { }
}
