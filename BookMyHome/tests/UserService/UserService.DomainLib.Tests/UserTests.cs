using UserService.DomainLib.Entities;
using UserService.DomainLib.Enums;

namespace UserService.DomainLib.Tests;

public class UserTests
{
    private readonly static string FirstName = "Tom";
    private readonly static string LastName = "Felton";
    private readonly static DateOnly Birthdate = new DateOnly(1987, 09, 27);
    private readonly static string Street = "Vejlevej 42";
    private readonly static string PostalCode = "7100";
    private readonly static string City = "Vejle";
    private readonly static string PhoneNumber = "12345678";
    private readonly static string Email = "test@test.dk";
    private readonly static UserRoles Role = UserRoles.Host;
    private readonly static string PasswordHash = "NotAHash";

    public static User CreateValidUser(
        UserId? userId = null,
        string? firstName = null,
        string? lastName = null,
        DateOnly? birthdate = null,
        string? street = null,
        string? postalCode = null,
        string? city = null,
        string? phoneNumber = null,
        string? email = null,
        UserRoles? role = null,
        string? passwordHash = null
        )
    {
        return User.Create(
            firstName ?? FirstName,
            lastName ?? LastName,
            birthdate ?? Birthdate,
            street ?? Street,
            postalCode ?? PostalCode,
            city ?? City,
            phoneNumber ?? PhoneNumber,
            email ?? Email,
            passwordHash ?? PasswordHash,
            role ?? Role
            );
    }

    [Fact]
    public void Create_GivenValidUser_SetsUsername()
    {
        // Arrange
        var expected = Email;

        // Act
        var user = CreateValidUser();

        // Assert
        Assert.Equal(expected, user.Username);
    }
}
