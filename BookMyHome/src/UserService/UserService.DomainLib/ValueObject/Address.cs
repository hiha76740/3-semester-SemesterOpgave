using BookMyHome.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.ValueObject;

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
    /// <param name="street"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <exception cref="DomainException"></exception>
    public Address(string street, string postalCode, string city)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new DomainException("Street can not be empty");

        if (string.IsNullOrWhiteSpace(postalCode))
            throw new DomainException("Postalcode can not be empty");

        if (string.IsNullOrWhiteSpace(city))
            throw new DomainException("City can not be empty");

        Street = street;
        PostalCode = postalCode;
        City = city;
    }
}
