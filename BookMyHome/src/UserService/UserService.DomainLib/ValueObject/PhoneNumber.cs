using BookMyHome.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.ValueObject;

/// <summary>
/// 
/// </summary>
public record PhoneNumber
{
    /// <summary>
    /// 
    /// </summary>
    public string Value { get; init; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="DomainException"></exception>
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Phone Number can not be empty");

        Value = value;
    }
}
