using UserService.DomainLib.Entities;

namespace UserService.ApplicationLib.Authentication;

public interface IRefreshTokenService
{
    public string GenerateRefreshToken();
}
