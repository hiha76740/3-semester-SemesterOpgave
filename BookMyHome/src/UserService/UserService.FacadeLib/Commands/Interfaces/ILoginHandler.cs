using UserService.FacadeLib.Commands.DTOs;

namespace UserService.FacadeLib.Commands.Interfaces;

public interface ILoginHandler
{
    Task<TokenDto?> HandleAsync(LoginCommand command);
}
