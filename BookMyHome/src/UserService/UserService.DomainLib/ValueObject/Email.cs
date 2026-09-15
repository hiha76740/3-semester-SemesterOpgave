using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.ValueObject;

public record Email
{
    public string EmailAddress { get; init; }

    public Email(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress))
            throw new DomainException("Email address can not be empty");

        EmailAddress = emailAddress;
    }
}
