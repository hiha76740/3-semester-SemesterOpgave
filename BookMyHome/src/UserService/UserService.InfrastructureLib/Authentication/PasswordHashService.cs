using Microsoft.AspNetCore.Identity;
using UserService.ApplicationLib.Authentication;

namespace UserService.InfrastructureLib.Authentication;

internal class PasswordHashService : IPasswordHashService
{
    private readonly PasswordHasher<object> _passwordHasher = new();
    private readonly object _passwordHasherUser = new();

    string IPasswordHashService.Hash(string password)
    {
        var hashedPassword = _passwordHasher.HashPassword(_passwordHasherUser, password);

        return hashedPassword;
    }

    bool IPasswordHashService.Verify(string password, string passwordHash)
    {
        throw new NotImplementedException();
    }
}
