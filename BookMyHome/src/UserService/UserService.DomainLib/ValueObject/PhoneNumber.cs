using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.ValueObject;

public record PhoneNumber
{
    public string Number { get; init; }

    public PhoneNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new DomainException("Phone Number can not be empty");

        Number = number;
    }
}
