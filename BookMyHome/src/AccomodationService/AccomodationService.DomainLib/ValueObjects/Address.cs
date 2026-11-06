using BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.DomainLib.ValueObjects;

/// <summary>
/// 
/// </summary>
public record Address
{
    /// <summary>
    /// 
    /// </summary>
    public string Street { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public string PostalCode { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public string City { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public string Country { get; init; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="street"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <param name="country"></param>
    /// <exception cref="DomainException"></exception>
    public Address(string street, string postalCode, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new DomainException("Street can not be empty");

        if (string.IsNullOrWhiteSpace(postalCode))
            throw new DomainException("Postalcode can not be empty");

        if (string.IsNullOrWhiteSpace(city))
            throw new DomainException("City can not be empty");

        if (string.IsNullOrWhiteSpace(country))
            throw new DomainException("Country can not be empty");

        Street = street;
        PostalCode = postalCode;
        City = city;
        Country = country;
    }
}
