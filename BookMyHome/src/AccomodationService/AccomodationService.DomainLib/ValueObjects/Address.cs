using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.DomainLib.ValueObjects;

public record Address
{
    public string Street { get; init; }
    public string PostalCode { get; init; }
    public string City { get; init; }

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
