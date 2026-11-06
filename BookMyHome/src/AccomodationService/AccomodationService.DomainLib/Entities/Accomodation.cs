using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;
using BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.DomainLib.Entities;

/// <summary>
/// 
/// </summary>
public class Accomodation
{
    /// <summary>
    /// 
    /// </summary>
    public AccomodationId Id { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string Title { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public HostId HostId { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public AccomodationStatus Status { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public Address Address { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string? ImageFileName { get; private set; }

    private readonly List<Listing> _listings = [];
    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyList<Listing> Listings => _listings.AsReadOnly();

    private readonly List<Facility> _facilities = [];
    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyList<Facility> Facilities => _facilities.AsReadOnly();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="imageFileName"></param>
    public void SetListingImage(ListingId id, string imageFileName)
    {
        var listing = GetListing(id);

        listing.SetImage(imageFileName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="imageFileName"></param>
    /// <exception cref="DomainException"></exception>
    public void SetImage(string imageFileName)
    {
        if (string.IsNullOrWhiteSpace(imageFileName))
            throw new DomainException("image file name must have a value");

        ImageFileName = imageFileName;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newStatus"></param>
    public void UpdateListingStatus(ListingId id, ListingStatus newStatus)
    {
        var listing = GetListing(id);

        listing.UpdateStatus(newStatus);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newStatus"></param>
    /// <exception cref="DomainException"></exception>
    public void UpdateStatus(AccomodationStatus newStatus)
    {
        if (Status == newStatus)
            throw new DomainException("new and old status can not be the same");

        Status = newStatus;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="listingName"></param>
    /// <param name="dailyPrice"></param>
    /// <param name="houseRules"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public ListingId CreateListing(string listingName, decimal dailyPrice, string houseRules, AccomodationType type)
    {
        var listing = new Listing(this, listingName, dailyPrice, houseRules, type);

        _listings.Add(listing);

        return listing.Id;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newAccomodationType"></param>
    public void UpdateAccomodationType(ListingId id, AccomodationType newAccomodationType)
    {
        var listing = GetListing(id);

        listing.UpdateAccomodationType(newAccomodationType);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newListingName"></param>
    public void UpdateListingName(ListingId id, string newListingName)
    {
        var listing = GetListing(id);

        listing.UpdateListingName(newListingName);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public void RemoveListing(ListingId id)
    {
        var listing = GetListing(id);

        _listings.Remove(listing);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newPrice"></param>
    public void UpdateListingDailyPrice(ListingId id, decimal newPrice)
    {

        var listing = GetListing(id);

        listing.UpdateDailyPrice(newPrice);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newHouseRules"></param>
    public void UpdateListingHouseRules(ListingId id, string newHouseRules)
    {
        var listing = GetListing(id);

        listing.UpdateHouseRules(newHouseRules);
    }

    private Listing GetListing(ListingId id)
    {
        var listing = _listings.FirstOrDefault(l => l.Id == id)
            ?? throw new DomainException("No losting was found");

        return listing;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="facility"></param>
    /// <exception cref="DomainException"></exception>
    public void AddFacility(Facility facility)
    {
        var exists = _facilities.Any(f => f.Id == facility.Id);

        if (exists == true)
            throw new DomainException("Facility is already added to this accomodation");

        _facilities.Add(facility);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="facility"></param>
    /// <exception cref="NotFoundException"></exception>
    public void RemoveFacility(Facility facility)
    {
        var exists = _facilities.Any(f => f.Name == facility.Name);

        if (exists == false)
            throw new NotFoundException("Unable to remove facility, was not found");

        _facilities.Remove(facility);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hostId"></param>
    /// <param name="title"></param>
    /// <param name="street"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <param name="country"></param>
    /// <param name="facilities"></param>
    /// <returns></returns>
    /// <exception cref="DomainException"></exception>
    public static Accomodation Create(HostId hostId, string title, string street, string postalCode, string city, string country, List<Facility> facilities)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title can not be empty");

        var address = new Address(street, postalCode, city, country);

        var accomodation = new Accomodation(hostId, title, address);

        if (facilities.Count > 0)
        {
            foreach (var facility in facilities)
            {
                accomodation.AddFacility(facility);
            }
        }

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
