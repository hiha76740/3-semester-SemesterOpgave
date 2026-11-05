using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.ValueObject;

public record Email
{
    public string Value { get; init; }

    public Email(string value)
    {
        if (value.Contains("@") == false)
            throw new DomainException("Email is not valid");

        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Email address can not be empty");

        Value = value.ToLower();
    }
}
