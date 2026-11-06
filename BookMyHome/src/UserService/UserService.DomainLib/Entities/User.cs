using BookMyHome.SharedKernelLib.Exceptions;
using UserService.DomainLib.Enums;
using UserService.DomainLib.ValueObject;

namespace UserService.DomainLib.Entities;
/// <summary>
/// 
/// </summary>
public class User
{
    /// <summary>
    /// 
    /// </summary>
    public UserId Id { get; init; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string FirstName { get; private set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string LastName { get; private set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public DateOnly Birthdate { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public Address Address { get; private set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public PhoneNumber PhoneNumber { get; private set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public Email Email { get; private set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public AccessRoles Role { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public string Username { get; init; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string PasswordHash { get; private set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string? RefreshToken { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime? RefreshTokenExpiryTime { get; private set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="birthdate"></param>
    /// <param name="street"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    /// <param name="passwordHash"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    /// <exception cref="DomainException"></exception>
    public static User Create(
        string firstName,
        string lastName,
        DateOnly birthdate,
        string street,
        string postalCode,
        string city,
        string phoneNumber,
        string email,
        string passwordHash,
        AccessRoles role
        )
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("First name can not be empty");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("Last name can not be empty");

        if (birthdate >= DateOnly.FromDateTime(DateTime.Today))
            throw new DomainException("Birth date has to be in the past");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("Password Hash can not be empty");

        if (birthdate >= DateOnly.FromDateTime(DateTime.Today).AddYears(-18))
            throw new DomainException("You need to be 18 years old to create an account");

        var address = new Address(street, postalCode, city);
        var pNumber = new PhoneNumber(phoneNumber);
        var emailAddress = new Email(email);

        var user = new User(firstName, lastName, birthdate, address, pNumber, emailAddress, passwordHash, role);

        return user;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="refreshExpiryTime"></param>
    /// <exception cref="DomainException"></exception>
    public void SetRefreshToken(string refreshToken, bool refreshExpiryTime)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
            throw new DomainException("refresh token could not be set, no value");

        if (refreshExpiryTime == true)
            RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

        RefreshToken = refreshToken;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newFirstName"></param>
    /// <exception cref="DomainException"></exception>
    public void ChangeFirstName(string newFirstName)
    {
        if (string.IsNullOrWhiteSpace(newFirstName))
            throw new DomainException("New firstname can not be empty");

        if (newFirstName == FirstName)
            throw new DomainException("New and old first name can not be the same");

        FirstName = newFirstName;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newLastName"></param>
    /// <exception cref="DomainException"></exception>
    public void ChangeLastName(string newLastName)
    {
        if (string.IsNullOrWhiteSpace(newLastName))
            throw new DomainException("New lastname can not be empty");

        if (newLastName == LastName)
            throw new DomainException("New and old lastname can not be the same");

        LastName = newLastName;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="street"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <exception cref="DomainException"></exception>
    public void ChangeAddress(string street, string postalCode, string city)
    {
        var newAddress = new Address(street, postalCode, city);

        if (Address == newAddress)
            throw new DomainException("New and old address can not be the same");

        Address = newAddress;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <exception cref="DomainException"></exception>
    public void ChangeEmail(string email)
    {
        var newEmail = new Email(email);

        if (Email == newEmail)
            throw new DomainException("New and old email can not be the same");

        Email = newEmail;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <exception cref="DomainException"></exception>
    public void ChangePhoneNumber(string phoneNumber)
    {
        var newPhoneNumber = new PhoneNumber(phoneNumber);

        if (PhoneNumber == newPhoneNumber)
            throw new DomainException("new and old phone number can not be the same");

        PhoneNumber = newPhoneNumber;
    }

    private User(string firstName, string lastName, DateOnly birthdate, Address address, PhoneNumber phoneNumber, Email email, string passwordHash, AccessRoles role)
    {
        Id = new UserId(Guid.NewGuid());
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
        Username = email.Value;
        PasswordHash = passwordHash;
        Role = role;
    }

    // EF constructor
    private User() { }
}
