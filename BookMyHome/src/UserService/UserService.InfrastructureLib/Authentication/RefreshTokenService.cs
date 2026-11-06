using System.Security.Cryptography;
using UserService.ApplicationLib.Authentication;

namespace UserService.InfrastructureLib.Authentication;

/// <summary>
/// 
/// </summary>
public class RefreshTokenService : IRefreshTokenService
{
    string IRefreshTokenService.GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}
