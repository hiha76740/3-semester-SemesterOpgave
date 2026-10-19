using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.ValueObject;

public record PhoneNumber
{
    public string Value { get; init; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Phone Number can not be empty");

        Value = value;
    }
}
