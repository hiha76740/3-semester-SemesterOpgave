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
    public Address Address { get; init; } = null!;

    private readonly List<Listing> _listings = [];
    public IReadOnlyList<Listing> listings => _listings.AsReadOnly();

    private readonly List<Facility> _facilities = [];
    public IReadOnlyList<Facility> facilities => _facilities.AsReadOnly();


    public void CreateListing(string listingName, decimal dailyPrice, string houseRules, AccomodationType type)
    {
        var listing = new Listing(this, listingName, dailyPrice, houseRules, type);

        _listings.Add(listing);
    }

    public void RemoveListing(ListingId id)
    {
        var listing = GetListing(id);

        _listings.Remove(listing);
    }

    public void UpdateListingDailyPrice(ListingId id, decimal newPrice)
    {

        var listing = GetListing(id);

        listing.UpdateDailyPrice(newPrice);
    }

    public void UpdateListingHouseRules(ListingId id, string newHouseRules)
    {
        var listing = GetListing(id);

        listing.UpdateHouseRules(newHouseRules);
    }

    private Listing GetListing(ListingId id)
    {
        var listing = _listings.FirstOrDefault(l => l.Id == id);

        if (listing == null)
            throw new DomainException("No losting was found");

        return listing;
    }


    public void AddFacility(Facility facility)
    {
        var exists = _facilities.Any(f => f.Id == facility.Id);

        if (exists == true)
            throw new DomainException("Facility is already added to this accomodation");

        _facilities.Add(facility);
    }

    public void RemoveFacility(Facility facility)
    {
        var exists = _facilities.Any(f => f.Name == facility.Name);

        if (exists == false)
            throw new NotFoundException("Unable to remove facility, was not found");

        _facilities.Remove(facility);
    }

    public static Accomodation Create(HostId hostId, string title, string street, string postalCode, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title can not be empty");

        var address = new Address(street, postalCode, city,country);

        var accomodation = new Accomodation(hostId, title, address);

        return accomodation;
    }

    private Accomodation(HostId hostId, string title, Address address)
    {
        Id = new AccomodationId(Guid.NewGuid());
        Title = title;
        HostId = hostId;
        Address = address;
        Status = AccomodationStatus.Active;
    }

    // EF constructor
    private Accomodation() { }
}
