using UserService.DomainLib.Entities;

namespace UserService.ApplicationLib.Authentication;

public interface ITokenService
{
    public string CreateToken(User user);
}
