using System.Globalization;
using BookMyHome.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.ValueObject;

/// <summary>
/// 
/// </summary>
public record Email
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
    public Email(string value)
    {
        if (value.Contains('@') == false)
            throw new DomainException("Email is not valid");

        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Email address can not be empty");

        Value = value.ToLower(CultureInfo.CurrentCulture);
    }
}
