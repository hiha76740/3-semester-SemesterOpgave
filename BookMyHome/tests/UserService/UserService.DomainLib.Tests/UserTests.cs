using UserService.DomainLib.Entities;
using UserService.DomainLib.Enums;

namespace UserService.DomainLib.Tests;

public class UserTests
{
    private static readonly string s_firstName = "Tom";
    private static readonly string s_lastName = "Felton";
    private static readonly DateOnly s_birthdate = new(1987, 09, 27);
    private static readonly string s_street = "Vejlevej 42";
    private static readonly string s_postalCode = "7100";
    private static readonly string s_city = "Vejle";
    private static readonly string s_phoneNumber = "12345678";
    private static readonly string s_email = "test@test.dk";
    private static readonly AccessRoles s_role = AccessRoles.Host;
    private static readonly string s_passwordHash = "NotAHash";

    public static User CreateValidUser(
        string? firstName = null,
        string? lastName = null,
        DateOnly? birthdate = null,
        string? street = null,
        string? postalCode = null,
        string? city = null,
        string? phoneNumber = null,
        string? email = null,
        AccessRoles? role = null,
        string? passwordHash = null
        )
    {
        return User.Create(
            firstName ?? s_firstName,
            lastName ?? s_lastName,
            birthdate ?? s_birthdate,
            street ?? s_street,
            postalCode ?? s_postalCode,
            city ?? s_city,
            phoneNumber ?? s_phoneNumber,
            email ?? s_email,
            passwordHash ?? s_passwordHash,
            role ?? s_role
            );
    }

    [Fact]
    public void Create_GivenValidUser_SetsUsername()
    {
        // Arrange
        var expected = s_email;

        // Act
        var user = CreateValidUser();

        // Assert
        Assert.Equal(expected, user.Username);
    }
}
